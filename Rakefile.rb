require 'rubygems'    

require 'albacore'
require 'rake/clean'
require 'git'
require 'noodle'
require 'set'

include FileUtils

solution_file = FileList["*.sln"].first
build_file = FileList["*.msbuild"].first
project_name = "MavenThought.Units"
commit = Git.open(".").log.first.sha[0..10] rescue 'na'
version = IO.readlines('VERSION')[0] rescue "0.0.0.0"
deploy_folder = "c:/temp/build/#{project_name}.#{version}_#{commit}"
merged_folder = "#{deploy_folder}/merged"
zip_file = "#{deploy_folder}/#{project_name}.#{version}_#{commit}.zip"

CLEAN.include("main/**/bin", "main/**/obj", "test/**/obj", "test/**/bin", "gem/lib/**", ".svn")

CLOBBER.include("**/_*", "**/.svn", "lib/*", "**/*.user", "**/*.cache", "**/*.suo")

msbuild_path = File.join(ENV['windir'], 'Microsoft.NET','Framework',  'v4.0.30319', 'MSBuild.exe')

desc 'Default build'
task :default => ["build:all"]

desc 'Setup requirements to build and deploy'
task :setup => ["setup:dep:download", "setup:dep:local"]

desc "Updates build version, generate zip, merged version and the gem in #{deploy_folder}"
task :deploy => ["deploy:all"]

desc "Run all unit tests"
task :test => ["test:all"]

namespace :setup do
	namespace :dep do
		task :download do 
			system "bundle install --system"
		end	
		Noodle::Rake::NoodleTask.new :local do |n|
			n.groups << :runtime
			n.groups << :dev
		end
	end
end

namespace :build do

	desc "Build the project"
	msbuild :all, :config do |msb, args|
		msb.properties :configuration => args[:config] || :Debug
		msb.targets :Build
		msb.solution = solution_file
	end

	desc "Rebuild the project"
	task :re => ["clean", "build:all"]
end

namespace :test do
	
	desc 'Run all tests'
	task :all do 
		tests = FileList["test/**/bin/debug/**/*.Tests.dll"].join " "
		system "./tools/gallio/bin/gallio.echo.exe #{tests}"
	end
	
end

namespace :deploy do

	task :all  => [:update_version] do
		rm_rf(deploy_folder)
		Dir.mkdir(deploy_folder) unless File.directory? deploy_folder
		Rake::Task["build:all"].invoke(:Release)
		Rake::Task["test:all"].invoke
		Rake::Task["deploy:package"].invoke
	end 
	
	task :update_version do 
		files = FileList["main/**/Properties/AssemblyInfo.cs"]
		files.each do |file| 
			Rake::Task["deploy:assemblyinfo"].invoke(file) 
			Rake::Task["deploy:assemblyinfo"].reenable 
		end
	end
	
	assemblyinfo :assemblyinfo, :file do |asm, args|
		asm.version = version
		asm.company_name = "MavenThought Inc."
		asm.product_name = "#{project_name}"
		asm.title = "#{project_name} (sha #{commit})"
		asm.description = "Unit library to be able to use units as type and interop with values"
		asm.copyright = "MavenThought Inc. 2010"
		asm.output_file = args[:file]
	end	

	task :package do
		[project_name].each do | proj |
			puts "Zip contents for #{proj}"
			Rake::Task["deploy:zip"].invoke(proj)
			Rake::Task["deploy:zip"].reenable
		end
	end
	
	zip :zip, :zip_project do |zip, args|
		zip.directories_to_zip "main/#{args[:zip_project]}/bin/release"
		zip.output_file =  "#{args[:zip_project]}.#{version}_#{commit}.zip"
		zip.output_path = deploy_folder
	end
	
	task :merge do
		puts "Merging #{project_name} assemblies located in bin/release into one"
		# Obtain unique list to be merged
		assemblies = FileList["main/**/bin/release/*.dll"].inject({}) do |hash, f| 
			hash[File.basename(f)] ||= f 
			hash
		end.values
		# Sort to put Maventhought first, so the attr are copied
		assemblies = assemblies.sort { |f1, f2| f1.include?( "#{project_name}.dll" ) ? -1 : 0 }.join ' '
		puts "Merging #{assemblies}"
		system "./tools/ilmerge/ILmerge.exe /out:#{project_name}.dll #{assemblies}"
		Dir.mkdir(merged_folder) unless File.directory? merged_folder
		mv("#{project_name}.dll", merged_folder)
		rm("#{project_name}.pdb")
	end

end

namespace :jeweler do
	require 'jeweler'

	desc 'Build the release and then the gem'
	task :buildit do
		Rake::Task["build:all"].invoke(:Release)
		files = Dir.glob("main/MavenThought.Units/bin/release/Maven*.dll")
		copy files, "lib"
		Rake::Task["jeweler:build"].invoke
	end
  	
	Jeweler::Tasks.new do |gs|
		gs.name = "maventhought.units"
		gs.summary = "Unit Classes to describe distance, weight, etc"
		gs.description = "The Unit library provides classes to be able to express and use units in a fluid easy way"
		gs.email = "amir@barylko.com"
		gs.homepage = "https://github.com/amirci/mt_units"
		gs.authors = ["Amir Barylko"]
		gs.has_rdoc = false 
		gs.rubyforge_project = 'maventhought.units'  
		gs.files = "lib/MavenThought.Units.dll"
	end
end
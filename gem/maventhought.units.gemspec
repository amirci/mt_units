version = File.read(File.expand_path("../VERSION",__FILE__)).strip  
  
Gem::Specification.new do |spec|  
  spec.name        = 'maventhought.units'  
  spec.version     = version  
  spec.files = Dir['lib/**/*'] + Dir['doc/**/*']
  
  spec.summary     = 'Unit Classes to describe distance, weight, etc'  
  spec.description = 'The Unit library provides classes to be able to express and use units in a fluid easy way'  
    
  spec.authors           = ['Amir Barylko']  
  spec.email             = 'amir@maventhought.com'  
  spec.homepage          = 'http://maventhought.com/units'  
  spec.rubyforge_project = 'maventhought.units'  
end  
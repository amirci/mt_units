using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting inches to feet
    /// </summary>
    [Specification]
    public class When_converts_inches_to_feet : ImperialConversionToFeetSpecification
    {
        /// <summary>
        /// Creates a new instance of <see cref="When_converts_inches_to_feet"/>
        /// </summary>
        public When_converts_inches_to_feet()
            : base(Imperial.Inches)
        {
        }

        /// <summary>
        /// Checks the conversion matches the expected
        /// </summary>
        [It]
        public void Should_divide_by_twelve()
        {
            Assert.AreEqual(this.Input / 12, this.Actual);
        }
    }
}
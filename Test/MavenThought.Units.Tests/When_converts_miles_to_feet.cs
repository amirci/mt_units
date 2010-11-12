using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting miles to feet
    /// </summary>
    [Specification]
    public class When_converts_miles_to_feet : ImperialConversionToFeetSpecification
    {
        /// <summary>
        /// Creates a new instance of <see cref="When_converts_miles_to_feet"/>
        /// </summary>
        public When_converts_miles_to_feet()
            : base(Imperial.Miles)
        {
        }

        /// <summary>
        /// Checks the conversion matches the expected
        /// </summary>
        [It]
        public void Should_return_5280_times_the_value()
        {
            Assert.AreEqual(this.Input * 5280, this.Actual);
        }
    }
}
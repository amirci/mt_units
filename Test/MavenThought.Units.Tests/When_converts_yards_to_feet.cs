using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting yard to feet
    /// </summary>
    [Specification]
    public class When_converts_yards_to_feet : ImperialConversionToFeetSpecification
    {
        /// <summary>
        /// Creates a new instance of <see cref="When_converts_yards_to_feet"/>
        /// </summary>
        public When_converts_yards_to_feet()
            : base(Imperial.Yards)
        {
        }

        /// <summary>
        /// Checks the conversion matches the expected
        /// </summary>
        [It]
        public void Should_return_3_times_the_value()
        {
            Assert.AreEqual(this.Input * 3, this.Actual);
        }
    }
}
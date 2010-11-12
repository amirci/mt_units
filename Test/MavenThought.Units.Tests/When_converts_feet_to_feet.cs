using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting feet to feet
    /// </summary>
    [Specification]
    public class When_converts_feet_to_feet : ImperialConversionToFeetSpecification
    {
        /// <summary>
        /// Creates a new instance of <see cref="When_converts_feet_to_feet"/>
        /// </summary>
        public When_converts_feet_to_feet()
            : base(Imperial.Feet)
        {
        }

        /// <summary>
        /// Checks the conversion matches the expected
        /// </summary>
        [It]
        public void Should_return_the_same_value()
        {
            Assert.AreEqual(this.Input, this.Actual);
        }
    }
}
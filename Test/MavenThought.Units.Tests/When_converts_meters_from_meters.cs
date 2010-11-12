using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting cms to meters
    /// </summary>
    [Specification]
    public class When_converts_meters_from_meters : MetricConversionFromSpecification
    {
        /// <summary>
        /// Creates a new instance of <see cref="When_converts_meters_from_meters"/>
        /// </summary>
        public When_converts_meters_from_meters()
            : base(Metric.Meters)
        {
        }

        /// <summary>
        /// Checks the conversion matches the expected
        /// </summary>
        [It]
        public void Should_be_the_same()
        {
            Assert.AreEqual(this.Input, this.Actual);
        }
    }
}
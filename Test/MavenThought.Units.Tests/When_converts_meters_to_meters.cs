using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting meters to meters
    /// </summary>
    [Specification]
    public class When_converts_meters_to_meters : MetricConversionToMetersSpecification
    {
        /// <summary>
        /// Creates a new instance of <see cref="When_converts_meters_to_meters"/> class.
        /// </summary>
        public When_converts_meters_to_meters()
            : base(Metric.Meters)
        {}

        /// <summary>
        /// Checks the conversion from meters to meters
        /// </summary>
        [It]
        public void Should_return_the_same_value()
        {
            Assert.AreEqual(this.Input, this.Actual);
        }
    }
}
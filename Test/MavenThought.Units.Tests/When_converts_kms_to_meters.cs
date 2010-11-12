using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting kms to meters
    /// </summary>
    [Specification]
    public class When_converts_kms_to_meters : MetricConversionToMetersSpecification
    {
        /// <summary>
        /// Creates a new instance of <see cref="When_converts_kms_to_meters"/>
        /// </summary>
        public When_converts_kms_to_meters()
            : base(Metric.Kms)
        {
        }

        /// <summary>
        /// Checks the conversion matches the expected
        /// </summary>
        [It]
        public void Should_multiply_by_one_hundred()
        {
            Assert.AreEqual(this.Input * 1000, this.Actual);
        }
    }
}
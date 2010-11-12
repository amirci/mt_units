using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting cms to meters
    /// </summary>
    [Specification]
    public class When_converts_kms_from_meters : MetricConversionFromSpecification
    {
        /// <summary>
        /// Creates a new instance of <see cref="When_converts_kms_from_meters"/>
        /// </summary>
        public When_converts_kms_from_meters()
            : base(Metric.Kms)
        {
        }

        /// <summary>
        /// Checks the conversion matches the expected
        /// </summary>
        [It]
        public void Should_divide_by_1000()
        {
            Assert.AreEqual(this.Input / 1000, this.Actual);
        }
    }
}
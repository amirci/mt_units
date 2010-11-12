using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting cms to meters
    /// </summary>
    [Specification]
    public class When_converts_cms_from_meters : MetricConversionFromSpecification
    {
        /// <summary>
        /// Creates a new instance of <see cref="When_converts_cms_from_meters"/>
        /// </summary>
        public When_converts_cms_from_meters()
            : base(Metric.Cms)
        {
        }

        /// <summary>
        /// Checks the conversion matches the expected
        /// </summary>
        [It]
        public void Should_multiply_by_one_hundred()
        {
            Assert.AreEqual(this.Input * 100, this.Actual);
        }
    }
}
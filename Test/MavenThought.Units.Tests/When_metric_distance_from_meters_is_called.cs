using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when from meters is called
    /// </summary>
    [Specification]
    public class When_metric_distance_from_meters_is_called
        : When_distance_conversion_from_base_value_is_called<MetricDistance, IMetricDistance>
    {
        /// <summary>
        /// Returns a new instance of the SUT
        /// </summary>
        /// <returns>A new instance of Imperial distance</returns>
        protected override IMetricDistance CreateSut()
        {
            return new MetricDistance("Metric", this.ConvertTo, this.ConvertFrom);
        }

        /// <summary>
        /// call conversion
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Sut.FromMeters(this.Input);
        }
    }
}
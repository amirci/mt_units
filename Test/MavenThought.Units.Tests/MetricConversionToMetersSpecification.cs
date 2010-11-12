namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Base specification for Metric class
    /// </summary>
    public abstract class MetricConversionToMetersSpecification
        : DimensionConversionSpecification<IMetricDistance>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MetricConversionToMetersSpecification"/> class.
        /// </summary>
        /// <param name="distance">Distance to use</param>
        protected MetricConversionToMetersSpecification(IMetricDistance distance)
            : base(distance)
        {
        }

        /// <summary>
        /// Convert to meters
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Distance.ToMeters(this.Input);
        }
    }
}
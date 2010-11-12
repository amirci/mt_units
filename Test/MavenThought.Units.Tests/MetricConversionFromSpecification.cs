namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Base specification for Metric class
    /// </summary>
    public abstract class MetricConversionFromSpecification
        : DimensionConversionSpecification<IMetricDistance>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MetricConversionFromSpecification"/> class.
        /// </summary>
        /// <param name="distance">Distance to use</param>
        protected MetricConversionFromSpecification(IMetricDistance distance)
            : base(distance)
        {
        }

        /// <summary>
        /// Convert to meters
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Distance.FromMeters(this.Input);
        }
    }
}
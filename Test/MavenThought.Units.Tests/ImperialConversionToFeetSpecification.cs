namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Base specification for Metric class
    /// </summary>
    public abstract class ImperialConversionToFeetSpecification
        : DimensionConversionSpecification<IImperialDistance>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MetricConversionToMetersSpecification"/> class.
        /// </summary>
        /// <param name="distance">Distance to use</param>
        protected ImperialConversionToFeetSpecification(IImperialDistance distance)
            : base(distance)
        {
        }

        /// <summary>
        /// Convert to feet
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Distance.ToFeet(this.Input);
        }
    }
}
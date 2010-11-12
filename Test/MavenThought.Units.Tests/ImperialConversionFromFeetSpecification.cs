namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Base specification for Metric class
    /// </summary>
    public abstract class ImperialConversionFromFeetSpecification
        : DimensionConversionSpecification<IImperialDistance>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ImperialConversionFromFeetSpecification"/> class.
        /// </summary>
        /// <param name="distance">Distance to use</param>
        protected ImperialConversionFromFeetSpecification(IImperialDistance distance)
            : base(distance)
        {
        }

        /// <summary>
        /// Convert to meters
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Distance.FromFeet(this.Input);
        }
    }
}
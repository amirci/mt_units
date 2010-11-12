using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when from feet method is called
    /// </summary>
    [Specification]
    public class When_imperial_distance_from_feet_is_called
        : When_distance_conversion_from_base_value_is_called<ImperialDistance, IImperialDistance>
    {
        /// <summary>
        /// Returns a new instance of the SUT
        /// </summary>
        /// <returns>A new instance of Imperial distance</returns>
        protected override IImperialDistance CreateSut()
        {
            return new ImperialDistance("Imperial",this.ConvertTo, this.ConvertFrom);
        }

        /// <summary>
        /// call conversion
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Sut.FromFeet(this.Input);
        }
    }
}
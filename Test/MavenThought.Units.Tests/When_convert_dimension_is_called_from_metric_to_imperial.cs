using System;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when the "In" extension is called from metric to metric
    /// </summary>
    [Specification]
    public class When_convert_dimension_is_called_from_metric_to_imperial : UnitExtensionsSpecification
    {
        /// <summary>
        /// Gets or sets the input measure unit
        /// </summary>
        protected Unit<IDistance> Input { get; set; }

        /// <summary>
        /// Expected dimension to be converted
        /// </summary>
        protected IImperialDistance ExpectedDimension { get; set; }

        /// <summary>
        /// Gets or sets the Actual value obtained
        /// </summary>
        protected IUnit<IDistance> Actual { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="When_convert_dimension_is_called_from_metric_to_imperial"/> class.
        /// </summary>
        /// <param name="index">Index to use</param>
        [Row(0)]
        [Row(1)]
        [Row(2)]
        [Row(3)]
        public When_convert_dimension_is_called_from_metric_to_imperial(int index)
        {
            this.ExpectedDimension = DimensionsFactory().ToList()[index];
        }

        /// <summary>
        /// Checks the assigned quantity is the expected
        /// </summary>
        [It]
        public void Should_have_assigned_the_expected_quantity()
        {
            var meters = ((IMetricDistance) this.Input.Dimension).ToMeters(this.Input.Quantity);

            var feet = meters * 3.2808398950131235;

            Assert.AreEqual(this.ExpectedDimension.FromFeet(feet), this.Actual.Quantity);
        }

        /// <summary>
        /// Checks the dimension obtained is the expected
        /// </summary>
        [It]
        public void Should_have_the_expected_dimension()
        {
            Assert.AreSame(this.ExpectedDimension, this.Actual.Dimension);
        }

        /// <summary>
        /// Setup the input unit measure
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            var random = new Random();

            this.Input = random.Next(0, 500).Meters();
        }

        /// <summary>
        /// Convert the unit to a metric
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Input.In(this.ExpectedDimension);
        }

        /// <summary>
        /// Factory for all metric dimensions
        /// </summary>
        /// <returns>A collection with all the metric dimensions</returns>
        private static IEnumerable<IImperialDistance> DimensionsFactory()
        {
            yield return Imperial.Feet;
            yield return Imperial.Inches;
            yield return Imperial.Miles;
            yield return Imperial.Yards;
        }
    }
}
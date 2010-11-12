using System;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when the "In" extension is called from imperial to metric
    /// </summary>
    [Specification]
    public class When_convert_dimension_is_called_from_imperial_to_metric : UnitExtensionsSpecification
    {
        /// <summary>
        /// Gets or sets the input measure unit
        /// </summary>
        protected IUnit<IDistance> Input { get; set; }

        /// <summary>
        /// Expected dimension to be converted
        /// </summary>
        protected IMetricDistance ExpectedDimension { get; set; }

        /// <summary>
        /// Gets or sets the Actual value obtained
        /// </summary>
        protected IUnit<IDistance> Actual { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="When_convert_dimension_is_called_from_metric_to_metric"/> class.
        /// </summary>
        /// <param name="index">Index to use</param>
        [Row(0)]
        [Row(1)]
        [Row(2)]
        public When_convert_dimension_is_called_from_imperial_to_metric(int index)
        {
            this.ExpectedDimension = DimensionsFactory().ToList()[index];
        }

        /// <summary>
        /// Checks the assigned quantity is the expected
        /// </summary>
        [It]
        public void Should_have_assigned_the_expected_quantity()
        {
            var feet = ((IImperialDistance)this.Input.Dimension).ToFeet(this.Input.Quantity);

            var meters = feet * 0.3048;

            Assert.AreEqual(this.ExpectedDimension.FromMeters(meters), this.Actual.Quantity);
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

            this.Input = random.Next(0, 500).Feet();
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
        private static IEnumerable<IMetricDistance> DimensionsFactory()
        {
            yield return Metric.Cms;
            yield return Metric.Meters;
            yield return Metric.Kms;
        }
    }
}
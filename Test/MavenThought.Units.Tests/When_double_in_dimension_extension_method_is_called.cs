using System;
using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when using the extension method to create a IUnit from a double ....
    /// </summary>
    [Specification]
    public class When_double_in_dimension_extension_method_is_called 
        : UnitExtensionsSpecification
    {
        /// <summary>
        /// Dimension expected
        /// </summary>
        private readonly IDistance _expectedDimension;

        /// <summary>
        /// Unit generator
        /// </summary>
        private readonly Func<double, IUnit<IDistance>> _generator;

        /// <summary>
        /// Initializes a new instance of the <see cref="When_double_in_dimension_extension_method_is_called"/> class. 
        /// </summary>
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="generator">
        /// The generator.
        /// </param>
        [Factory("DimensionFactory")]
        public When_double_in_dimension_extension_method_is_called(IDistance expected,
                                                                   Func<double, IUnit<IDistance>> generator)
        {
            this._expectedDimension = expected;
            this._generator = generator;
        }

        /// <summary>
        /// Gets or sets the actual value for the unit
        /// </summary>
        protected IUnit<IDistance> Actual { get; set; }

        /// <summary>
        /// Gets or sets the input to use for the test
        /// </summary>
        protected double Input { get; set; }

        /// <summary>
        /// The quantity should match
        /// </summary>
        [It]
        public void Should_have_quantity_matching()
        {
            Assert.AreEqual(this.Input, this.Actual.Quantity);
        }

        /// <summary>
        /// Checks the right dimension was assigned
        /// </summary>
        [It]
        public void Should_have_the_expected_dimension()
        {
            var concrete = this.Actual;

            Assert.AreSame(this._expectedDimension, concrete.Dimension);
        }

        /// <summary>
        /// Setup the input value
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Input = new Random().NextDouble();
        }

        /// <summary>
        /// Creates a concrete distance value
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this._generator(this.Input);
        }

        /// <summary>
        /// Index factory
        /// </summary>
        /// <returns></returns>
        protected static IEnumerable<int> IndexFactory()
        {
            return DimensionFactory().ForEach((i, e) => i);
        }

        /// <summary>
        /// Generates pairs of dimension and generators
        /// </summary>
        /// <returns>A collection of pairs with IDistance and unit generators</returns>
        private static IEnumerable<object[]> DimensionFactory()
        {
            yield return new object[] { Imperial.Inches, new Func<double, IUnit<IDistance>>(x => x.Inches()) };
            yield return new object[] { Imperial.Feet, new Func<double, IUnit<IDistance>>(x => x.Feet()) };
            yield return new object[] { Imperial.Yards, new Func<double, IUnit<IDistance>>(x => x.Yards()) };
            yield return new object[] { Imperial.Miles, new Func<double, IUnit<IDistance>>(x => x.Miles()) };
            yield return new object[] { Metric.Meters, new Func<double, IUnit<IDistance>>(x => x.Meters()) };
            yield return new object[] { Metric.Cms, new Func<double, IUnit<IDistance>>(x => x.Cms()) };
            yield return new object[] { Metric.Kms, new Func<double, IUnit<IDistance>>(x => x.Kms()) };

        }

    }
}
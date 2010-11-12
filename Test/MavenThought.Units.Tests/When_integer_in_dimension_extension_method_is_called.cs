using System;
using System.Collections.Generic;
using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when using the extension method to create a IUnit....
    /// </summary>
    [Specification]
    public class When_integer_in_dimension_extension_method_is_called : UnitExtensionsSpecification
    {
        /// <summary>
        /// Dimension expected
        /// </summary>
        private readonly IDistance _expectedDimension;

        /// <summary>
        /// Unit generator
        /// </summary>
        private readonly Func<int, IUnit<IDistance>> _generator;

        /// <summary>
        /// Initializes a new instance of <see cref="When_integer_in_dimension_extension_method_is_called"/> class.
        /// </summary>
        [Factory("DimensionFactory")]
        public When_integer_in_dimension_extension_method_is_called(IDistance dimension, Func<int, IUnit<IDistance>> functor)
        {
            this._expectedDimension = dimension;
            this._generator = functor;
        }

        /// <summary>
        /// Gets or sets the actual value for the unit
        /// </summary>
        protected IUnit<IDistance> Actual { get; set; }

        /// <summary>
        /// Gets or sets the input to use for the test
        /// </summary>
        protected int Input { get; set; }

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

            this.Input = new Random().Next();
        }

        /// <summary>
        /// Creates a concrete distance value
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = _generator(this.Input);
        }

        /// <summary>
        /// Generates pairs of dimension and generators
        /// </summary>
        /// <returns>A collection of pairs with IDistance and unit generators</returns>
        protected static IEnumerable<object[]> DimensionFactory()
        {
            yield return new object[] { Imperial.Inches, new Func<int, IUnit<IDistance>>(x => x.Inches()) };
            yield return new object[] { Imperial.Feet, new Func<int, IUnit<IDistance>>(x => x.Feet()) };
            yield return new object[] { Imperial.Yards, new Func<int, IUnit<IDistance>>(x => x.Yards()) };
            yield return new object[] { Imperial.Miles, new Func<int, IUnit<IDistance>>(x => x.Miles()) };
            yield return new object[] { Metric.Meters, new Func<int, IUnit<IDistance>>(x => x.Meters()) };
            yield return new object[] { Metric.Cms, new Func<int, IUnit<IDistance>>(x => x.Cms()) };
            yield return new object[] { Metric.Kms, new Func<int, IUnit<IDistance>>(x => x.Kms()) };
        }

    }
}
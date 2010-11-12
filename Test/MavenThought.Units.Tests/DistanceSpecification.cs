using System;
using MavenThought.Commons.Testing;
using Rhino.Mocks;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Base specification for distance
    /// </summary>
    public abstract class DistanceSpecification<TDistance, TContract> : 
        AutoMockSpecification<TDistance, TContract> 
        where TDistance : class, TContract
        where TContract : IDimension
    {
        /// <summary>
        /// Gets or sets the value to convert to base value
        /// </summary>
        protected Func<double, double> ConvertTo { get; private set; }

        /// <summary>
        /// Actual obtained value
        /// </summary>
        protected double Actual { get; set; }

        /// <summary>
        /// Input to use
        /// </summary>
        protected double Input { get; set; }

        /// <summary>
        /// Expected value
        /// </summary>
        protected double Expected { get; set; }

        /// <summary>
        /// Gets or sets the functor to convert from base dimension
        /// </summary>
        protected Func<double, double> ConvertFrom { get; private set; }

        /// <summary>
        /// Setup input and expected
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.ConvertTo = MockIt(this.ConvertTo);

            this.ConvertFrom = MockIt(this.ConvertFrom);

            var random = new Random();

            this.Input = random.NextDouble();

            this.Expected = random.NextDouble();

            this.ConvertTo.Stub(c => c(this.Input)).Return(this.Expected);

            this.ConvertFrom.Stub(c => c(this.Input)).Return(this.Expected);
        }
    }
}
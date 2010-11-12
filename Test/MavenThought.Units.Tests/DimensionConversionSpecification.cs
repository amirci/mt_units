using System;
using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Base class for unit conversion specification
    /// </summary>
    /// <typeparam name="TDistance"></typeparam>
    public abstract class DimensionConversionSpecification<TDistance> 
        : BaseSpecification
        where TDistance : IDistance
    {

        /// <summary>
        /// Gets or sets the metric distance to use
        /// </summary>
        protected TDistance Distance { get; private set; }

        /// <summary>
        /// Gets or sets the actual obtained value
        /// </summary>
        protected double Actual { get; set; }

        /// <summary>
        /// Gets or sets the Input to use
        /// </summary>
        protected double Input { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="DimensionConversionSpecification{TDistance}"/>
        /// </summary>
        /// <param name="distance">Distance instance to use</param>
        protected DimensionConversionSpecification(TDistance distance)
        {
            this.Distance = distance;
        }

        /// <summary>
        /// Setup the input value
        /// </summary>
        protected override void GivenThat()
        {
            var random = new Random();

            this.Input = random.NextDouble();
        }
    }
}
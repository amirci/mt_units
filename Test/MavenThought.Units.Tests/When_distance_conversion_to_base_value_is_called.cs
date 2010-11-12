using MavenThought.Commons.Testing;
using Rhino.Mocks;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Base specification when distance is called
    /// </summary>
    /// <typeparam name="TDistance">Distance class to use
    /// </typeparam>
    /// <typeparam name="TContract">Contract for the distance class
    /// </typeparam>
    public abstract class When_distance_conversion_to_base_value_is_called<TDistance, TContract>
        : DistanceSpecification<TDistance, TContract> 
        where TDistance : class, TContract 
        where TContract : IDimension
    {
        /// <summary>
        /// Checks the converter is called
        /// </summary>
        [It]
        public void Should_call_the_conversion_functor()
        {
            this.ConvertTo.AssertWasCalled(c => c(this.Input));
        }

        /// <summary>
        /// Checks the returned value matches the expected
        /// </summary>
        [It]
        public void Should_return_the_expected_value()
        {
            Assert.AreEqual(this.Expected, this.Actual);
        }
    }
}
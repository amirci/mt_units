using MavenThought.Commons.Testing;
using Rhino.Mocks;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Base specification when distance is called
    /// </summary>
    public abstract class When_distance_conversion_from_base_value_is_called<TDistance, TContract>
        : DistanceSpecification<TDistance, TContract>
        where TDistance : class, TContract
        where TContract : IDimension
    {
        /// <summary>
        /// Checks the converter is called
        /// </summary>
        [It]
        public void Should_call_the_conversion_functor_from_base_value()
        {
            this.ConvertFrom.AssertWasCalled(c => c(this.Input));
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
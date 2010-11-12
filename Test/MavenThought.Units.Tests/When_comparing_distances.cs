using MavenThought.Commons.Testing;
using MbUnit.Framework;
using SharpTestsEx;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when comparing to distances
    /// </summary>
    [Specification]
    public class When_comparing_distances : UnitExtensionsSpecification
    {
        private readonly double _d1;
        private readonly double _d2;
        private bool _actual;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        public When_comparing_distances([RandomNumbers(Minimum = 1, Maximum = 5, Count = 5)]double d1,
            [RandomNumbers(Minimum = 1, Maximum = 5, Count = 5)]double d2)
        {
            _d1 = d1;
            _d2 = d2;
        }

        /// <summary>
        /// Comparison check
        /// </summary>
        [It]
        public void Should_compare_equality()
        {
            _actual
                .Should().Be
                .EqualTo(_d1.Equals(_d2));
        }

        /// <summary>
        /// Check equality
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this._d1.Inches().Is().EqualTo(this._d2.Inches());
        }
    }
}
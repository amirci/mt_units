using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when comparing two units of the same dimension
    /// </summary>
    [Specification]
    public class When_comparing_two_area_units
        : UnitSpecification<IArea>
    {
        private readonly IUnit<IArea> _sut;
        private readonly IUnit<IArea> _other;
        private readonly int _expected;

        /// <summary>
        /// actual value obtained
        /// </summary>
        private int _actual;

        /// <summary>
        /// Initializes a new instance of <see cref="When_comparing_two_distance_units"/>
        /// </summary>
        [Row(0)]
        [Row(1)]
        [Row(2)]
        public When_comparing_two_area_units(int index)
        {
            var row = UnitFactory().ElementAt(index);

            _sut = (IUnit<IArea>)row[0];
            _other = (IUnit<IArea>)row[1];
            _expected = (int)row[2];
        }

        /// <summary>
        /// Checks the result is the expected
        /// </summary>
        [It]
        public void Should_return_match_expected()
        {
            this._actual.Should().Be.EqualTo(this._expected);
        }

        /// <summary>
        /// Creates the instance of the SUT
        /// </summary>
        /// <returns>SUT to test with</returns>
        protected override IUnit<IArea> CreateSut()
        {
            return this._sut;
        }

        /// <summary>
        /// Compare the two units
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.CompareTo(this._other);
        }

        /// <summary>
        /// Factory to create values for the test
        /// </summary>
        /// <returns>A collection of parameters for the test</returns>
        public static IEnumerable<object[]> UnitFactory()
        {
            yield return new object[] { 10.Square().Inches, 10.Square().Meters, -1 };

            yield return new object[]
                             {
                                 10.Square().Meters,
                                 10.Square().Inches,
                                 1
                             };

            yield return new object[]
                             {
                                 12.Square().Inches,
                                 1.Square().Feet,
                                 0
                             };
        }
    }
}
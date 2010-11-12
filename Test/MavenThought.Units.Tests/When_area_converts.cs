using System.Collections.Generic;
using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Specification when converting area values
    /// </summary>
    [ConstructorSpecification]
    public class When_area_converts : AreaConversionSpecification
    {
        /// <summary>
        /// Checks the actual matches the expected
        /// </summary>
        [Factory("UnitFactory")]
        [It]
        public void Should_match_the_expected(IUnit<IArea> actual, IUnit<IArea> expected)
        {
            Assert.AreApproximatelyEqual(actual.Quantity, expected.Quantity, 0.001, "{0} should be equal to {1}", actual, expected);
        }

        /// <summary>
        /// Factory to create the units
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> UnitFactory()
        {
            yield return new object[] { 1.Square().Feet.In().Inches, 144.Square().Inches };

            yield return new object[] { 144.Square().Inches.In().Feet, 1.Square().Feet };

            yield return new object[] { 1.Square().Yards.In().Feet, 9.Square().Feet };

            yield return new object[] { 9.Square().Feet.In().Yards, 1.Square().Yards };

            yield return new object[] { 1.Square().Meters.In().Feet, 10.7639104167097.Square().Feet };

            yield return new object[] { 100.Square().Meters.In().Yards, 119.599.Square().Yards };

            yield return new object[] { 100.Square().Miles.In().Kms, 258.998.Square().Kms };
        }
    }
}
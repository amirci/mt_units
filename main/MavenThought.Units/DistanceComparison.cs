namespace MavenThought.Units
{
    /// <summary>
    /// Comparison for distances
    /// </summary>
    public class DistanceComparison : IUnitComparison<IDistance>
    {
        private readonly IUnit<IDistance> _unit;

        /// <summary>
        /// Initializes a new instance of <see cref="DistanceComparison"/>
        /// </summary>
        /// <param name="unit"></param>
        public DistanceComparison(IUnit<IDistance> unit)
        {
            _unit = unit;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool EqualTo(IUnit<IDistance> other)
        {
            return this._unit.In().Feet.Quantity
                .Equals(other.In().Feet.Quantity);
        }

        /// <summary>
        /// Greater than operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool GreaterThan(IUnit<IDistance> other)
        {
            return this._unit.In().Feet.Quantity > other.In().Feet.Quantity;
        }

        /// <summary>
        /// Less than operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool LessThan(IUnit<IDistance> other)
        {
            return this._unit.In().Feet.Quantity < other.In().Feet.Quantity;
        }

        /// <summary>
        /// Less or equal to operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool LessOrEqualTo(IUnit<IDistance> other)
        {
            return this._unit.In().Feet.Quantity <= other.In().Feet.Quantity;
        }

        /// <summary>
        /// Greater or equal to operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool GreaterOrEqualTo(IUnit<IDistance> other)
        {
            return this._unit.In().Feet.Quantity >= other.In().Feet.Quantity;
        }
    }
}
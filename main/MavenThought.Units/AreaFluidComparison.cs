namespace MavenThought.Units
{
    /// <summary>
    /// Implementation of unit comparison
    /// </summary>
    public class AreaFluidComparison : IUnitComparison<IArea>
    {
        /// <summary>
        /// Unit to compare with
        /// </summary>
        private readonly AreaUnit _unit;

        /// <summary>
        /// Initializes a new instance of <see cref="AreaFluidComparison"/>
        /// </summary>
        /// <param name="unit"></param>
        public AreaFluidComparison(IUnit<IArea> unit)
        {
            _unit = (AreaUnit) unit;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool EqualTo(IUnit<IArea> other)
        {
            var a1 = (AreaUnit) other;

            return this._unit.Distance.Is().EqualTo(a1.Distance);
        }

        /// <summary>
        /// Greater than operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool GreaterThan(IUnit<IArea> other)
        {
            var a1 = (AreaUnit)other;

            return this._unit.Distance.Is().GreaterThan(a1.Distance);
        }

        /// <summary>
        /// Less than operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool LessThan(IUnit<IArea> other)
        {
            var a1 = (AreaUnit)other;

            return this._unit.Distance.Is().LessThan(a1.Distance);
        }

        /// <summary>
        /// Less or equal to operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool LessOrEqualTo(IUnit<IArea> other)
        {
            var a1 = (AreaUnit)other;

            return this._unit.Distance.Is().LessOrEqualTo(a1.Distance);
        }

        /// <summary>
        /// Greater or equal to operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool GreaterOrEqualTo(IUnit<IArea> other)
        {
            var a1 = (AreaUnit)other;

            return this._unit.Distance.Is().GreaterOrEqualTo(a1.Distance);
        }
    }
}
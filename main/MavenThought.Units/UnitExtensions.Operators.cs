namespace MavenThought.Units
{
    public static partial class DistanceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static IUnitComparison<IDistance> Is(this IUnit<IDistance> unit)
        {
            return new DistanceComparison(unit);
        }

        /// <summary>
        /// Converts the distance into area
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static IUnit<IArea> Times(this IUnit<IDistance> d1, IUnit<IDistance> d2)
        {
            var f1 = d1.In().Feet;
            var f2 = d2.In().Feet;

            return (f1.Quantity * f2.Quantity).Square().Feet;
        }

        /// <summary>
        /// Multiply the distance by a number
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double Times(this IUnit<IDistance> d1, double val)
        {
            return d1.Quantity * val;
        } 
    }
}
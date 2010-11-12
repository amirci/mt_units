using System;
using System.Diagnostics;

namespace MavenThought.Units
{
    /// <summary>
    /// Extensions for area
    /// </summary>
    public static class AreaExtensions
    {
        /// <summary>
        /// Extension method to allow fluid conversion
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static IUnitFluidConverter<IArea> In(this IUnit<IArea> unit)
        {
            return new AreaFluidConverter(unit);
        }

        /// <summary>
        /// Convert an area unit to Imperial
        /// </summary>
        /// <param name="unit">Instance of the measure</param>
        /// <param name="dimension"> New Dimension to convert </param>
        /// <returns> A new measure with the conversion </returns>
        public static IUnit<IArea> In(this IUnit<IArea> unit, IDistance dimension)
        {
            Debug.WriteLine("**** converting area to " + dimension);

            var area = (AreaUnit) unit;

            var converter = DistanceConverter.From(area.Distance.Dimension, dimension, 2);

            if (converter == null)
            {
                var message = string.Format("I don't know how to convert area {0} to {1}", unit, dimension);

                throw new InvalidOperationException(message);
            }

            var quantity = converter(unit.Quantity);

            return new AreaUnit(new DistanceUnit(quantity, dimension));
        }

        /// <summary>
        /// Extension method to allow comparisons like area.Is().EqualTo....
        /// </summary>
        /// <param name="area">Area to compare</param>
        /// <returns>A compare instance to select the comparison</returns>
        public static IUnitComparison<IArea> Is(this IUnit<IArea> area)
        {
            return new AreaFluidComparison(area);
        }

        /// <summary>
        /// Creates a square area
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static IUnitFluidConverter<IArea> Square(this int number)
        {
            return new AreaFromNumberFluidConverter(number);
        }

        /// <summary>
        /// Creates a square area
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static IUnitFluidConverter<IArea> Square(this double number)
        {
            return new AreaFromNumberFluidConverter(number);
        }
    }
}
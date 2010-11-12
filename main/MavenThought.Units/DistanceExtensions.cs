using System;
using MavenThought.Commons.Patterns;

namespace MavenThought.Units
{
    /// <summary>
    /// Extension for unit classes
    /// </summary>
    public static partial class DistanceExtensions
    {
        /// <summary>
        /// Convert a measure unit to Metric
        /// </summary>
        /// <typeparam name="TDistance"> Type of the measure </typeparam>
        /// <param name="unit"> Instance of the measure </param>
        /// <param name="dimension"> New Dimension to convert </param>
        /// <returns> A new measure with the conversion </returns>
        public static IUnit<IDistance> In<TDistance>(this IUnit<TDistance> unit, IDistance dimension)
            where TDistance : IDistance
        {
            var dispatcher = new VisitorDispatcher();

            var result = (IUnit<IDistance>) dispatcher.Accept(unit.Dimension.GetType(), 
                                                              new DistanceConverterVisitor(), 
                                                              unit.Quantity, 
                                                              unit.Dimension, 
                                                              dimension);

            if (result == null)
            {
                var message = string.Format("I don't know how to convert {0} to metric", unit.Dimension.GetType());

                throw new InvalidOperationException(message);
            }

            return result;
        }

        /// <summary>
        /// Extension method to allow fluid conversion like unit.In().Inches
        /// </summary>
        /// <param name="unit">Unit to be converted</param>
        /// <returns>The converter instance</returns>
        public static IUnitFluidConverter<IDistance> In(this IUnit<IDistance> unit)
        {
            return new DistanceFluidConverter(unit);
        }

        /// <summary>
        /// Converter from imperial to metric and vice versa
        /// </summary>
        public sealed class DistanceConverterVisitor
        {
            /// <summary>
            /// Converts to the metric distance given a metric distance
            /// </summary>
            /// <param name="quantity">
            /// Quantity to convert
            /// </param>
            /// <param name="source">
            /// Source distance
            /// </param>
            /// <param name="dimension">
            /// Target distance
            /// </param>
            /// <returns>
            /// A new unit of measure with the quantity converted to the target distance
            /// </returns>
            public IUnit<IDistance> VisitMetricDistance(double quantity, IMetricDistance source, IMetricDistance dimension)
            {
                var meters = source.ToMeters(quantity);

                return new DistanceUnit(dimension.FromMeters(meters), dimension);
            }

            /// <summary>
            /// Converts an imperial distance to a metric distance
            /// </summary>
            /// <param name="quantity"> Quantity to convert </param>
            /// <param name="source"> Source distance </param>
            /// <param name="target"> Target distance </param>
            /// <returns> A new unit of measure with the quantity converted to the target distance </returns>
            public IUnit<IDistance> VisitImperialDistance(double quantity, IImperialDistance source, IMetricDistance target)
            {
                var feet = source.ToFeet(quantity);

                var meters = feet * 0.3048;

                return new DistanceUnit(target.FromMeters(meters), target);
            }

            /// <summary>
            /// Converts the metric distance to an imperial distance
            /// </summary>
            /// <param name="quantity">Quantity to convert</param>
            /// <param name="source">Source dimension</param>
            /// <param name="target">Target dimension</param>
            /// <returns>A new unit of measure with the quantity expressed in the target distance</returns>
            public IUnit<IDistance> VisitMetricDistance(double quantity, IMetricDistance source, IImperialDistance target)
            {
                var meters = source.ToMeters(quantity);

                var feet = meters * 3.2808398950131235;

                return new DistanceUnit(target.FromFeet(feet), target);
            }

            /// <summary>
            /// Converts the imperial to imperial
            /// </summary>
            /// <param name="quantity">Quantity to convert</param>
            /// <param name="source">Source dimension</param>
            /// <param name="target">Target dimension</param>
            /// <returns>A new unit of measure with the quantity converted to the target dimension</returns>
            public IUnit<IDistance> VisitImperialDistance(double quantity, IImperialDistance source, IImperialDistance target)
            {
                var feet = source.ToFeet(quantity);

                return new DistanceUnit(target.FromFeet(feet), target);
            }
        }
    }
}
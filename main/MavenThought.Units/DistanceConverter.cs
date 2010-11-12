using System;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Patterns;

namespace MavenThought.Units
{
    /// <summary>
    /// Converts from one distance dimension to another
    /// </summary>
    public class DistanceConverter
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="DistanceConverter"/> class from being created. 
        /// </summary>
        private DistanceConverter()
        {            
        }

        /// <summary>
        /// Find the converter functor from source to target
        /// </summary>
        /// <param name="source">Dimension to convert from</param>
        /// <param name="target">Dimension to concert to</param>
        /// <param name="power"></param>
        /// <returns>A functor to convert from source into target</returns>
        public static Func<double, double> From(IDimension source, IDistance target, int power)
        {
            var dispatcher = new VisitorDispatcher("Convert");

            var result = dispatcher.Accept(source.GetType(), new DistanceConverter(), source, target, power);

            return (Func<double, double>)result;
        }

        /// <summary>
        /// Converts from one imperial unit to another
        /// </summary>
        /// <param name="source">Source imperial distance</param>
        /// <param name="target">Target imperial distance</param>
        /// <param name="power">Power to use (single, square, cubic, etc)</param>
        /// <returns>The functor to convert from one dimension to another</returns>
        protected Func<double, double> ConvertImperialDistance(IImperialDistance source, IImperialDistance target, int power)
        {
            var from = ((AbstractDistance) source).ConvertToBase;

            var to = ((AbstractDistance) target).ConvertFromBase;

            return x => Powerade(from, x, power, to);
        }

        /// <summary>
        /// Converts metric to metric
        /// </summary>
        /// <param name="source">Source dimension</param>
        /// <param name="target">Target dimension</param>
        /// <param name="power"></param>
        /// <returns>A functor that converts metric to metric</returns>
        protected Func<double, double> ConvertMetricDistance(IMetricDistance source, IMetricDistance target, int power)
        {
            var from = ((AbstractDistance)source).ConvertToBase;

            var to = ((AbstractDistance)target).ConvertFromBase;

            return x => Powerade(from, x, power, to);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        protected Func<double, double> ConvertMetricDistance(IMetricDistance source, IImperialDistance target, int power)
        {
            var from = ((AbstractDistance)source).ConvertToBase;

            var to = ((AbstractDistance)target).ConvertFromBase;

            Func<double, double> from2 = x => from(x) * 3.2808398950131235;

            return x => Powerade(from2, x, power, to);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        protected Func<double, double> ConvertImperialDistance(IImperialDistance source, IMetricDistance target, int power)
        {
            var from = ((AbstractDistance)source).ConvertToBase;

            var to = ((AbstractDistance)target).ConvertFromBase;

            Func<double, double> from2 = x => from(x) * 0.3048;

            return x => Powerade(from2, x, power, to);
        }
        
        /// <summary>
        /// Applies each functor using the indicated power
        /// </summary>
        /// <param name="from"></param>
        /// <param name="x"></param>
        /// <param name="power"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static double Powerade(Func<double, double> from, double x, int power, Func<double, double> to)
        {
            var result = from(x);

            var result1 = result;

            (power - 1).Times(() => result1 = from(result1));

            result = result1;

            power.Times(() => result = to(result));

            return result;
        }

    }
}
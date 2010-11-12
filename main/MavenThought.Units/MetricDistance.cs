using System;

namespace MavenThought.Units
{
    /// <summary>
    /// Implementation of a metric distance
    /// </summary>
    public class MetricDistance : AbstractDistance, IMetricDistance
    {
        /// <summary>
        /// Initialize a new instance of <see cref="MetricDistance"/>
        /// </summary>
        /// <param name="name">Name to show in to string</param>
        /// <param name="toMeters">Functor to use to convert to meters</param>
        /// <param name="fromMeters">Functor to convert from meters</param>
        public MetricDistance(string name, Func<double, double> toMeters, Func<double, double> fromMeters) 
            : base(name, toMeters, fromMeters)
        {
        }

        /// <summary>
        /// Convert to meters a value
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <returns>The value in meters</returns>
        public double ToMeters(double value)
        {
            return this.ConvertToBase(value);
        }

        /// <summary>
        /// Convert to value from meters
        /// </summary>
        /// <param name="meters">Value in meters to use</param>
        /// <returns>The value in the current distance</returns>
        public double FromMeters(double meters)
        {
            return this.ConvertFromBase(meters);
        }
    }
}
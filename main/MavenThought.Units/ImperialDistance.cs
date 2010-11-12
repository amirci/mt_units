using System;

namespace MavenThought.Units
{
    /// <summary>
    /// Implementation of imperial distance using a functor to convert to feet
    /// </summary>
    public class ImperialDistance : AbstractDistance, IImperialDistance
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ImperialDistance"/>.
        /// </summary>
        /// <param name="name">Name of the distance to be shown in to string</param>
        /// <param name="converter">Functor to convert to Feet</param>
        /// <param name="convertFrom">Functor to convert from Feet</param>
        public ImperialDistance(string name, Func<double, double> converter, Func<double, double> convertFrom) 
            : base(name, converter, convertFrom)
        {
        }

        /// <summary>
        /// Converts the value to inches
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <returns>The value converted to inches</returns>
        public double ToFeet(double value)
        {
            return this.ConvertToBase(value);
        }

        /// <summary>
        /// Converts the value from feet to current dimension
        /// </summary>
        /// <param name="value">Value in feet to convert</param>
        /// <returns>The value converted to current dimension</returns>
        public double FromFeet(double value)
        {
            return this.ConvertFromBase(value);
        }
    }
}
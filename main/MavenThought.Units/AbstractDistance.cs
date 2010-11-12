using System;

namespace MavenThought.Units
{
    /// <summary>
    /// Abstract implementation for distances with a functor to do the conversion
    /// </summary>
    public abstract class AbstractDistance : IDistance
    {
        /// <summary>
        /// Name to show
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Initialize a new instance of <see cref="MetricDistance"/> class.
        /// </summary>
        /// <param name="name">Name of the dimension</param>
        /// <param name="convertTo">Functor to use to convert to base value</param>
        /// <param name="convertFrom">Functor to convert from base value</param>
        protected AbstractDistance(string name, Func<double, double> convertTo, Func<double, double> convertFrom)
        {
            _name = name;
            this.ConvertToBase = convertTo;
            this.ConvertFromBase = convertFrom;
        }

        /// <summary>
        /// Gets or sets the functor to convert to base value
        /// </summary>
        public Func<double, double> ConvertToBase { get; private set; }

        /// <summary>
        /// Gets or sets the functor to convert from the base value
        /// </summary>
        public Func<double, double> ConvertFromBase { get; private set; }

        /// <summary>
        /// Returns the name of the dimension
        /// </summary>
        /// <returns>Name of the dimension</returns>
        public override string ToString()
        {
            return this._name;
        }
    }
}
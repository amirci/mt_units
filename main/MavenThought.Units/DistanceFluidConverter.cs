namespace MavenThought.Units
{
    /// <summary>
    /// Distance converter implementation
    /// </summary>
    public class DistanceFluidConverter : IDistanceFluidConverter
    {
        /// <summary>
        /// Unit instance to be converted
        /// </summary>
        private readonly IUnit<IDistance> _unit;

        /// <summary>
        /// Initializes a new instance of <see cref="DistanceFluidConverter"/>
        /// </summary>
        /// <param name="unit"></param>
        public DistanceFluidConverter(IUnit<IDistance> unit)
        {
            _unit = unit;
        }

        /// <summary>
        /// Gets the unit in Inches
        /// </summary>
        public IUnit<IDistance> Inches
        {
            get { return this._unit.In(Imperial.Inches); }
        }

        /// <summary>
        /// Gets the unit in Feet
        /// </summary>
        public IUnit<IDistance> Feet
        {
            get { return this._unit.In(Imperial.Feet); }
        }

        /// <summary>
        /// Gets the unit in Miles
        /// </summary>
        public IUnit<IDistance> Miles
        {
            get { return this._unit.In(Imperial.Miles); }
        }

        /// <summary>
        /// Gets the unit in Yards
        /// </summary>
        public IUnit<IDistance> Yards
        {
            get {  return this._unit.In(Imperial.Yards); }
        }

        /// <summary>
        /// Gets the unit in meters
        /// </summary>
        public IUnit<IDistance> Meters
        {
            get { return this._unit.In(Metric.Meters); }
        }

        /// <summary>
        /// Gets the unit in centimeters
        /// </summary>
        public IUnit<IDistance> Cms
        {
            get { return this._unit.In(Metric.Cms); }
        }

        /// <summary>
        /// Gets the unit in Kilometers
        /// </summary>
        public IUnit<IDistance> Kms
        {
            get { return this._unit.In(Metric.Kms); }
        }
    }
}
namespace MavenThought.Units
{
    /// <summary>
    /// Implementation of area converter
    /// </summary>
    public class AreaFluidConverter : IUnitFluidConverter<IArea>
    {
        /// <summary>
        /// Area to convert
        /// </summary>
        private readonly AreaUnit _area;

        /// <summary>
        /// Initializes a new instance of <see cref="AreaFluidConverter"/>
        /// </summary>
        /// <param name="area">Area to use</param>
        public AreaFluidConverter(IUnit<IArea> area)
        {
            _area = (AreaUnit) area;
        }

        /// <summary>
        /// Gets the unit in Inches
        /// </summary>
        public IUnit<IArea> Inches
        {
            get { return this._area.In(Imperial.Inches); }
        }

        /// <summary>
        /// Gets the unit in Feet
        /// </summary>
        public IUnit<IArea> Feet
        {
            get { return this._area.In(Imperial.Feet); }
        }

        /// <summary>
        /// Gets the unit in Miles
        /// </summary>
        public IUnit<IArea> Miles
        {
            get { return this._area.In(Imperial.Miles); }
        }

        /// <summary>
        /// Gets the unit in Yards
        /// </summary>
        public IUnit<IArea> Yards
        {
            get { return this._area.In(Imperial.Yards); }
        }

        /// <summary>
        /// Gets the unit in meters
        /// </summary>
        public IUnit<IArea> Meters
        {
            get { return this._area.In(Metric.Meters); }
        }

        /// <summary>
        /// Gets the unit in centimeters
        /// </summary>
        public IUnit<IArea> Cms
        {
            get { return this._area.In(Metric.Cms); }
        }

        /// <summary>
        /// Gets the unit in Kilometers
        /// </summary>
        public IUnit<IArea> Kms
        {
            get { return this._area.In(Metric.Kms); }
        }
    }
}
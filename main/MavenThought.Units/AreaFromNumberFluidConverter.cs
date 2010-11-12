namespace MavenThought.Units
{
    /// <summary>
    /// Implementation of square unit creator
    /// </summary>
    public class AreaFromNumberFluidConverter : IUnitFluidConverter<IArea>
    {
        /// <summary>
        /// Value to use as area
        /// </summary>
        private readonly double _area;

        /// <summary>
        /// Initializes a new instance of <see cref="AreaFromNumberFluidConverter"/>
        /// </summary>
        /// <param name="area">Number to return as area</param>
        public AreaFromNumberFluidConverter(double area)
        {
            _area = area;
        }


        /// <summary>
        /// Gets the unit in Inches
        /// </summary>
        public IUnit<IArea> Inches
        {
            get { return new AreaUnit(this._area.Inches());  }
        }

        /// <summary>
        /// Gets the unit in Feet
        /// </summary>
        public IUnit<IArea> Feet
        {
            get { return new AreaUnit(this._area.Feet()); }
        }

        /// <summary>
        /// Gets the unit in Miles
        /// </summary>
        public IUnit<IArea> Miles
        {
            get { return new AreaUnit(this._area.Miles()); }
        }

        /// <summary>
        /// Gets the unit in Yards
        /// </summary>
        public IUnit<IArea> Yards
        {
            get { return new AreaUnit(this._area.Yards()); }
        }

        /// <summary>
        /// Gets the unit in meters
        /// </summary>
        public IUnit<IArea> Meters
        {
            get { return new AreaUnit(this._area.Meters()); }
        }

        /// <summary>
        /// Gets the unit in centimeters
        /// </summary>
        public IUnit<IArea> Cms
        {
            get { return new AreaUnit(this._area.Cms()); }
        }

        /// <summary>
        /// Gets the unit in Kilometers
        /// </summary>
        public IUnit<IArea> Kms
        {
            get { return new AreaUnit(this._area.Kms()); }
        }
    }
}
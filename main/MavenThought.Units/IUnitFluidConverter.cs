namespace MavenThought.Units
{
    /// <summary>
    /// Base unit creator
    /// </summary>
    /// <typeparam name="TDimension"></typeparam>
    public interface IUnitFluidConverter<TDimension> where TDimension : IDimension
    {
        /// <summary>
        /// Gets the unit in Inches
        /// </summary>
        IUnit<TDimension> Inches { get; }

        /// <summary>
        /// Gets the unit in Feet
        /// </summary>
        IUnit<TDimension> Feet { get; }

        /// <summary>
        /// Gets the unit in Miles
        /// </summary>
        IUnit<TDimension> Miles { get; }

        /// <summary>
        /// Gets the unit in Yards
        /// </summary>
        IUnit<TDimension> Yards { get; }

        /// <summary>
        /// Gets the unit in meters
        /// </summary>
        IUnit<TDimension> Meters { get; }

        /// <summary>
        /// Gets the unit in centimeters
        /// </summary>
        IUnit<TDimension> Cms { get; }

        /// <summary>
        /// Gets the unit in Kilometers
        /// </summary>
        IUnit<TDimension> Kms { get; }
    }
}
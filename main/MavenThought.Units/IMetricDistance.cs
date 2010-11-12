namespace MavenThought.Units
{
    /// <summary>
    /// Metric distance dimension
    /// </summary>
    public interface IMetricDistance : IDistance
    {
        /// <summary>
        /// Convert to meters a value
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <returns>The value in meters</returns>
        double ToMeters(double value);

        /// <summary>
        /// Convert to value from meters
        /// </summary>
        /// <param name="meters">Value in meters to use</param>
        /// <returns>The value in the current distance</returns>
        double FromMeters(double meters);
    }
}
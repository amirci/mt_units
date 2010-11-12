namespace MavenThought.Units
{
    /// <summary>
    /// Imperial distance dimension
    /// </summary>
    public interface IImperialDistance : IDistance
    {
        /// <summary>
        /// Converts the value to feet
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <returns>The value converted to inches</returns>
        double ToFeet(double value);

        /// <summary>
        /// Converts the value from feet to current dimension
        /// </summary>
        /// <param name="value">Value in feet to convert</param>
        /// <returns>The value converted to current dimension</returns>
        double FromFeet(double value);
    }
}
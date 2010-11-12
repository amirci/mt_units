namespace MavenThought.Units
{
    public partial class DistanceExtensions
    {
        /// <summary>
        /// Create a new instance of a meters unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static Unit<IDistance> Meters(this int number)
        {
            return Meters((double)number);
        }

        /// <summary>
        /// Create a new instance of a CMS unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static Unit<IDistance> Cms(this int number)
        {
            return Cms((double) number);
        }

        /// <summary>
        /// Create a new instance of a KMS unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static Unit<IDistance> Kms(this int number)
        {
            return Kms((double)number);
        }

        /// <summary>
        /// Create a new instance of a meters unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static Unit<IDistance> Meters(this double number)
        {
            return new DistanceUnit(number, Metric.Meters);
        }

        /// <summary>
        /// Create a new instance of a CMS unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static Unit<IDistance> Cms(this double number)
        {
            return new DistanceUnit(number, Metric.Cms);
        }

        /// <summary>
        /// Create a new instance of a KMS unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static Unit<IDistance> Kms(this double number)
        {
            return new DistanceUnit(number, Metric.Kms);
        }
    }
}

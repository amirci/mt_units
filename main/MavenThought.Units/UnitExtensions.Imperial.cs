namespace MavenThought.Units
{
    public partial class DistanceExtensions
    {
        /// <summary>
        /// Create a new instance of a inches unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static IUnit<IDistance> Inches(this int number)
        {
            return Inches((double)number);
        }

        /// <summary>
        /// Create a new instance of a feet unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static IUnit<IDistance> Feet(this int number)
        {
            return Feet((double)number);
        }

        /// <summary>
        /// Create a new instance of a yard unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static IUnit<IDistance> Yards(this int number)
        {
            return Yards((double)number);
        }

        /// <summary>
        /// Create a new instance of a miles unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static IUnit<IDistance> Miles(this int number)
        {
            return Miles((double)number);
        }

        /// <summary>
        /// Create a new instance of a inches unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static IUnit<IDistance> Inches(this double number)
        {
            return new DistanceUnit(number, Imperial.Inches);
        }

        /// <summary>
        /// Create a new instance of a feet unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static IUnit<IDistance> Feet(this double number)
        {
            return new DistanceUnit(number, Imperial.Feet);
        }

        /// <summary>
        /// Create a new instance of a yard unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static IUnit<IDistance> Yards(this double number)
        {
            return new DistanceUnit(number, Imperial.Yards);
        }

        /// <summary>
        /// Create a new instance of a miles unit
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>An instance of a unit with the specified value and dimension</returns>
        public static IUnit<IDistance> Miles(this double number)
        {
            return new DistanceUnit(number, Imperial.Miles);
        }
    }
}

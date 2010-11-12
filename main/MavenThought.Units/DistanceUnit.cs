namespace MavenThought.Units
{
    /// <summary>
    /// Unit for distances
    /// </summary>
    public class DistanceUnit : Unit<IDistance>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DistanceUnit"/>
        /// </summary>
        /// <param name="number"></param>
        /// <param name="dimension"></param>
        public DistanceUnit(double number, IDistance dimension) 
            : base(number, dimension)
        {
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: 
        ///                     Value 
        ///                     Meaning 
        ///                     Less than zero 
        ///                     This object is less than the <paramref name="other"/> parameter.
        ///                     Zero 
        ///                     This object is equal to <paramref name="other"/>. 
        ///                     Greater than zero 
        ///                     This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public override int CompareTo(IUnit<IDistance> other)
        {
            return this.In().Feet.Quantity.CompareTo(other.In().Feet.Quantity);
        }

        /// <summary>
        /// Returns a string with the distance representation
        /// </summary>
        /// <returns>A string with "X distance name"</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Quantity, this.Dimension);
        }
    }
}
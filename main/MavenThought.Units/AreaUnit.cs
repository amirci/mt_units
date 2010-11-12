namespace MavenThought.Units
{
    /// <summary>
    /// Implementation of a unit of area
    /// </summary>
    public class AreaUnit : Unit<IArea>
    {
        /// <summary>
        /// Instance of area
        /// </summary>
        private static readonly IArea Area = new AreaInstance();

        /// <summary>
        /// Initializes a new instance of <see cref=" AreaUnit"/>
        /// </summary>
        /// <param name="distance"></param>
        public AreaUnit(IUnit<IDistance> distance)
            : base(distance.Quantity, Area)
        {
            Distance = distance;
        }

        /// <summary>
        /// Distance to use in the area
        /// </summary>
        public IUnit<IDistance> Distance { get; set; }
    
        /// <summary>
        /// Implementation of area
        /// </summary>
        internal class AreaInstance : IArea
        {
        }

        /// <summary>
        /// Returns a string with the representation of the area
        /// </summary>
        /// <returns>A string says "X Square YYY"</returns>
        public override string ToString()
        {
            return string.Format("{0} Square {1}", this.Distance.Quantity, this.Distance.Dimension);
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
        public override int CompareTo(IUnit<IArea> other)
        {
            var otherArea = (AreaUnit) other;

            return this.Distance.CompareTo(otherArea.Distance);
        }
    }
}
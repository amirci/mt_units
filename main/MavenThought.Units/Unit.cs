namespace MavenThought.Units
{
    /// <summary>
    /// Unit of measure for a particular dimension
    /// </summary>
    /// <typeparam name="TDimension">Dimension to use</typeparam>
    public abstract class Unit<TDimension> : IUnit<TDimension> 
        where TDimension : IDimension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Unit{TDimension}"/>
        /// </summary>
        /// <param name="number"></param>
        /// <param name="dimension"></param>
        protected Unit(double number, TDimension dimension)
        {
            this.Quantity = number;
            this.Dimension = dimension;
        }

        /// <summary>
        /// Gets the amount associated with the unit
        /// </summary>
        public double Quantity { get; protected set; }

        /// <summary>
        /// Gets the dimension of the unit
        /// </summary>
        public TDimension Dimension { get; protected set; }

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
        public abstract int CompareTo(IUnit<TDimension> other);

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        public bool Equals(Unit<TDimension> other)
        {
            return !ReferenceEquals(null, other) &&
                   (ReferenceEquals(this, other) || this.CompareTo(other) == 0);

        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) &&
                   (ReferenceEquals(this, obj) ||
                    ((obj is Unit<TDimension>) && Equals((Unit<TDimension>) obj)));
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Quantity.GetHashCode() * 397) ^ Dimension.GetHashCode();
            }
        }
    }
}
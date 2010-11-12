namespace MavenThought.Units
{
    /// <summary>
    /// Interface to compare units
    /// </summary>
    public interface IUnitComparison<T> where T : IDimension
    {
        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool EqualTo(IUnit<T> other);
        
        /// <summary>
        /// Greater than operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool GreaterThan(IUnit<T> other);

        /// <summary>
        /// Less than operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool LessThan(IUnit<T> other);

        /// <summary>
        /// Less or equal to operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool LessOrEqualTo(IUnit<T> other);

        /// <summary>
        /// Greater or equal to operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool GreaterOrEqualTo(IUnit<T> other);
    }
}
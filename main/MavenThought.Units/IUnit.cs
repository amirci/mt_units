using System;

namespace MavenThought.Units
{
    /// <summary>
    /// Unit of measure for a particular dimension
    /// </summary>
    /// <typeparam name="TDimension">Dimension to use</typeparam>
    public interface IUnit<TDimension> : IComparable<IUnit<TDimension>> 
        where TDimension : IDimension
    {
        /// <summary>
        /// Gets the amount associated with the unit
        /// </summary>
        double Quantity { get; }

        /// <summary>
        /// Gets the dimension of the unit
        /// </summary>
        TDimension Dimension { get; }
    }
}
using MavenThought.Commons.Testing;

namespace MavenThought.Units.Tests
{
    /// <summary>
    /// Base specification for Unit
    /// </summary>
    public abstract class UnitSpecification<TDimension>
        : AutoMockSpecification<Unit<TDimension>, IUnit<TDimension>> 
        where TDimension : IDimension
    {        
    }
}
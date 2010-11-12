namespace MavenThought.Units
{
    /// <summary>
    /// Imperial units of measure
    /// </summary>
    public static class Imperial
    {
        /// <summary>
        /// Backing field for Inches
        /// </summary>
        private static readonly IImperialDistance _inches = new ImperialDistance("Inches", x => x / 12, x => x * 12);

        /// <summary>
        /// Backing field for feet
        /// </summary>
        private static readonly IImperialDistance _feet = new ImperialDistance("Feet", x => x, x => x);

        /// <summary>
        /// Backing field for miles
        /// </summary>
        private static readonly IImperialDistance _miles = new ImperialDistance("Miles", x => x * 5280, x => x / 5280);

        /// <summary>
        /// Backing field for yards
        /// </summary>
        private static readonly IImperialDistance _yards = new ImperialDistance("Yards", x => x * 3, x => x / 3);

        /// <summary>
        /// Inches implementation
        /// </summary>
        public static IImperialDistance Inches { get { return _inches; } }

        /// <summary>
        /// Feet implementation
        /// </summary>
        public static IImperialDistance Feet { get { return _feet;}}

        /// <summary>
        /// Miles implementation
        /// </summary>
        public static IImperialDistance Miles { get { return _miles; } }

        /// <summary>
        /// Yards implementation
        /// </summary>
        public static IImperialDistance Yards { get { return _yards; } }

        /// <summary>
        /// Gets the base unit for imperial
        /// </summary>
        public static IImperialDistance Base { get { return Feet; } }
    }
}
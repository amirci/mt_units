namespace MavenThought.Units
{
    /// <summary>
    /// Metric implementations
    /// </summary>
    public static class Metric
    {
        /// <summary>
        /// Backing field for meters
        /// </summary>
        private static readonly IMetricDistance _meters = new MetricDistance("Meters", x => x, x=>x);

        /// <summary>
        /// Backing field for CMS
        /// </summary>
        private static readonly IMetricDistance _cms = new MetricDistance("Cms", x => x / 100, x=> x * 100);

        /// <summary>
        /// Backing field for kilometers
        /// </summary>
        private static readonly IMetricDistance _kms = new MetricDistance("Kms", x => x * 1000, x => x / 1000);

        /// <summary>
        /// Meters implementation
        /// </summary>
        public static IMetricDistance Meters { get { return _meters; } }

        /// <summary>
        /// Centimeters implementation
        /// </summary>
        public static IMetricDistance Cms { get { return _cms; } }

        /// <summary>
        /// Kilometers implementation
        /// </summary>
        public static IMetricDistance Kms { get { return _kms; } }

        /// <summary>
        /// Base unit for Metric
        /// </summary>
        public static IMetricDistance Base { get { return Meters; } }
    }
}
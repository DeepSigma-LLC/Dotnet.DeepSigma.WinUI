using DeepSigma.WinUI.Charting.Enum;
using DeepSigma.WinUI.Charting.Interfaces;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents an axis in a chart with various configurable properties.
    /// </summary>
    public abstract class AxisAbstract : IAxis
    {
        /// <summary>
        /// A unique identifier for the axis.
        /// </summary>
        public required string Key { get; set; }

        /// <summary>
        /// The title of the axis.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// The type of the axis (e.g., Linear, Logarithmic).
        /// </summary>
        public AxisType AxisType { get; set; } = AxisType.Linear;

        /// <summary>
        /// Indicates whether to show grid lines on the axis.
        /// </summary>
        public bool ShowMajorGridLines { get; set; } = true;

        /// <summary>
        /// Indicates whether to show minor grid lines on the axis.
        /// </summary>
        public bool ShowMinorGridLines { get; set; } = false;

        /// <summary>
        /// The style of the major grid lines.
        /// </summary>
        public ChartLineStyle MajorGridlineStyle { get; set; } = ChartLineStyle.None;

        /// <summary>
        /// The style of the minor grid lines.
        /// </summary>
        public ChartLineStyle MinorGridlineStyle { get; set; } = ChartLineStyle.None;

        /// <summary>
        /// The minimum value of the axis. Set to NaN for automatic scaling.
        /// </summary>
        public double Minimum { get; set; } = double.NaN;

        /// <summary>
        /// The maximum value of the axis. Set to NaN for automatic scaling.
        /// </summary>
        public double Maximum { get; set; } = double.NaN;

        /// <summary>
        /// The format string for the axis labels. Set to null for default formatting.
        /// </summary>
        public string? AxisFormatString { get; set; } = null;
        /// <summary>
        /// The starting location of the axis in relative terms (0 to 1).
        /// </summary>
        public double StartLocation { get; set; } = 0;
        /// <summary>
        /// The ending location of the axis in relative terms (0 to 1).
        /// </summary>
        public double EndLocation { get; set; } = 1.0;

        /// <summary>
        /// Indicates whether panning is enabled on the axis.
        /// </summary>
        public bool IsPanEnabled { get; set; } = true;

        /// <summary>
        /// Indicates whether zooming is enabled on the axis.
        /// </summary>
        public bool IsZoomEnabled { get; set; } = true;
    }
}

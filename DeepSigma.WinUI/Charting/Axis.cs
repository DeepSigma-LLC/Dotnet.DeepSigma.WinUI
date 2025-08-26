using DeepSigma.WinUI.Charting.Enum;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents an axis in a chart with various configurable properties.
    /// </summary>
    public class Axis
    {
        /// <summary>
        /// A unique identifier for the axis.
        /// </summary>
        public required string Key { get; set; }

        /// <summary>
        /// The title of the axis.
        /// </summary>
        public string Title { get; set; } = "Axis Title";

        /// <summary>
        /// The type of the axis (e.g., Linear, Logarithmic).
        /// </summary>
        public AxisType AxisType { get; set; } = AxisType.Linear;

        /// <summary>
        /// The position of the axis on the chart (e.g., Left, Right, Top, Bottom).
        /// </summary>
        public ChartAxisPosition AxisPosition { get; set; } = ChartAxisPosition.Left;

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
        public ChartLineStyle MajorGridlineStyle { get; set; } = ChartLineStyle.Solid;

        /// <summary>
        /// The style of the minor grid lines.
        /// </summary>
        public ChartLineStyle MinorGridlineStyle { get; set; } = ChartLineStyle.Dot;

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
    }
}

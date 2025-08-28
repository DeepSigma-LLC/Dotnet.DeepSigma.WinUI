using DeepSigma.WinUI.Charting.Enum;

namespace DeepSigma.WinUI.Charting.Interfaces
{
    /// <summary>
    /// Defines the properties and methods for configuring an axis in a chart.
    /// </summary>
    public interface IAxis
    {
        /// <summary>
        /// Gets or sets the format string for the axis labels.
        /// </summary>
        string? AxisFormatString { get; set; }
        /// <summary>
        /// Gets or sets the type of the axis (e.g., Linear, Logarithmic, Category).
        /// </summary>
        AxisType AxisType { get; set; }

        /// <summary>
        /// Unique key to identify the axis (e.g., "X", "Y", "Y2").
        /// </summary>
        string Key { get; set; }
        /// <summary>
        /// Major gridline style for the axis.
        /// </summary>
        ChartLineStyle MajorGridlineStyle { get; set; }
        /// <summary>
        /// Maximum value of the axis. Set to double.NaN for automatic scaling.
        /// </summary>
        double Maximum { get; set; }
        /// <summary>
        /// Minimum value of the axis. Set to double.NaN for automatic scaling.
        /// </summary>
        double Minimum { get; set; }
        /// <summary>
        /// Minor gridline style for the axis.
        /// </summary>
        ChartLineStyle MinorGridlineStyle { get; set; }
        /// <summary>
        /// Indicates whether to show major grid lines on the axis.
        /// </summary>
        bool ShowMajorGridLines { get; set; }
        /// <summary>
        /// Shows or hides minor grid lines on the axis.
        /// </summary>
        bool ShowMinorGridLines { get; set; }
        /// <summary>
        /// The title of the axis.
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// The location where the axis starts in the chart (0.0 to 1.0).
        /// </summary>
        double StartLocation { get; set; }
        /// <summary>
        /// The location where the axis ends in the chart (0.0 to 1.0).
        /// </summary>
        double EndLocation { get; set; }
        /// <summary>
        /// Indicates whether panning is enabled for the axis.
        /// </summary>
        bool IsPanEnabled { get; set; }
        /// <summary>
        /// Indicates whether zooming is enabled for the axis.
        /// </summary>
        bool IsZoomEnabled { get; set; }
    }
}
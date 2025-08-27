using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents a series of data points in a chart.
    /// </summary>
    public class ChartSeries<T> where T : IDataModel
    {
        /// <summary>
        /// The name of the data series.
        /// </summary>
        public string SeriesName { get; set; } = "Series Name";

        /// <summary>
        /// The type of chart series (e.g., Line, Scatter).
        /// </summary>
        public ChartSeriesType ChartSeriesType { get; set; } = ChartSeriesType.Line;

        /// <summary>
        /// The color of the data series.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Indicates whether the data points should be interpolated.
        /// </summary>
        public bool Interpolated { get; set; } = false;

        /// <summary>
        /// The collection of data points in the series.
        /// </summary>
        public DataSeries<T> Data { get; set; } = new();

        /// <summary>
        /// The primary axis.
        /// </summary>
        public required IAxis PrimaryAxis { get; set; }

        /// <summary>
        /// The secondard axis.
        /// </summary>
        public required IAxis SecondardyAxis { get; set; }

        /// <summary>
        /// The third axis used for 3D charts. Default value is null.
        /// </summary>
        public IAxis? TertiaryAxis { get; set; }
    }
}

using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;
using DeepSigma.WinUI.Charting.Interfaces;
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
    public abstract class ChartSeriesAbstract : IChartSeriesAbstract
    {
        /// <summary>
        /// The name of the data series.
        /// </summary>
        public required string SeriesName { get; set; } = string.Empty;

        /// <summary>
        /// The color of the data series.
        /// </summary>
        public Color Color { get; set; } = Color.Blue;

        /// <summary>
        /// Indicates whether the data points should be interpolated.
        /// </summary>
        public bool Interpolated { get; set; } = false;


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

        /// <summary>
        /// The data series containing the data points.
        /// </summary>
        public DataSeries<IDataModel> Data { get; set; } = new DataSeries<IDataModel>(); 
    }
}

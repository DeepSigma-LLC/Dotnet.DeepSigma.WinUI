using DeepSigma.WinUI.Charting.DataModels;
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
        public DataSeries<T> DataPoints { get; set; } = new();
    }
}

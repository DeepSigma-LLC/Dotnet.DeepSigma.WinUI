using DeepSigma.WinUI.Charting.DataModels;
using System.Collections.Generic;
using System.Drawing;

namespace DeepSigma.WinUI.Charting.Interfaces
{
    /// <summary>
    /// Defines the structure for a chart series.
    /// </summary>
    public interface IChartSeriesAbstract
    {
        /// <summary>
        /// The color of the series.
        /// </summary>
        Color Color { get; set; }
        /// <summary>
        /// The data points in the series.
        /// </summary>
        DataSeries<IDataModel> Data { get; set; }
        /// <summary>
        /// Indicates whether the series should be interpolated.
        /// </summary>
        bool Interpolated { get; set; }
        /// <summary>
        /// The name of the series.
        /// </summary>
        string SeriesName { get; set; }
        /// <summary>
        /// The axes associated with the series, identified by an integer key.
        /// </summary>
        SortedList<int, IAxis> Axes {get;set;}
    }
}
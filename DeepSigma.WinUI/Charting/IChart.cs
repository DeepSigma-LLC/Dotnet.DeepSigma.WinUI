using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;
using System.Collections.Generic;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents a chart with axes, series, and various properties.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IChart<T> where T : IAxis
    {
        /// <summary>
        /// Gets the collection of axes for the chart.
        /// </summary>
        IAxisCollectionAbstract<T> Axes { get; init; }

        /// <summary>
        /// Gets or sets the type of the chart (e.g., Line, Bar, Pie).
        /// </summary>
        ChartType ChartType { get; set; }

        /// <summary>
        /// Gets the collection of data series to be plotted on the chart.
        /// </summary>
        List<ChartSeries<IDataModel>> Series { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether to display the chart legend.
        /// </summary>
        bool ShowLegend { get; set; }

        /// <summary>
        /// Gets or sets the title of the chart.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Retrieves the series of a specific data model type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<ChartSeries<T>> GetSeries<T>() where T : IDataModel;
    }
}
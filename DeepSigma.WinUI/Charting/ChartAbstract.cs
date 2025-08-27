using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;
using DeepSigma.WinUI.Charting.Interfaces;


namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents a chart with various properties and configurations.
    /// </summary>
    public abstract class ChartAbstract<T> : IChart<T> where T : IAxis 
    {
        /// <summary>
        /// The title of the chart.
        /// </summary>
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// The collection of data series in the chart.
        /// </summary>
        public List<IChartSeriesAbstract<IDataModel>> Series { get; init; } = [];

        /// <summary>
        /// Gets all series of a specific data model type.
        /// </summary>
        /// <returns></returns>
        public List<IChartSeriesAbstract<IDataModel>> GetSeries()
        {
            return Series;
        }

        /// <summary>
        /// Indicates whether to show the legend.
        /// </summary>
        public bool ShowLegend { get; set; } = true;

        /// <summary>
        /// The collection of axes in the chart.
        /// </summary>
        public abstract IAxisCollectionAbstract<T> Axes { get; init; }
    }
}

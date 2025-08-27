using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;


namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents a chart with various properties and configurations.
    /// </summary>
    public abstract class ChartAbstract<T, D> : IChart<T, D> where T : IAxis where D : IDataModel
    {
        /// <summary>
        /// The title of the chart.
        /// </summary>
        public string Title { get; set; } = "Chart Title";

        /// <summary>
        /// The collection of data series in the chart.
        /// </summary>
        public List<ChartSeries<D>> Series { get; init; } = [];

        /// <summary>
        /// Gets all series of a specific data model type.
        /// </summary>
        /// <returns></returns>
        public List<ChartSeries<D>> GetSeries()
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

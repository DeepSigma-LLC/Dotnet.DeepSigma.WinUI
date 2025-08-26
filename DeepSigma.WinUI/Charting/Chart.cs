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
    public class Chart
    {
        /// <summary>
        /// The title of the chart.
        /// </summary>
        public string Title { get; set; } = "Chart Title";

        /// <summary>
        /// The collection of data series in the chart.
        /// </summary>
        public List<ChartSeries<IDataModel>> Series { get; init; } = [];

        /// <summary>
        /// Gets all series of a specific data model type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<ChartSeries<T>> GetSeries<T>() where T : IDataModel
        {
            return Series.Where(s => s is ChartSeries<T>).Cast<ChartSeries<T>>().ToList();
        }
   

        /// <summary>
        /// The type of chart (e.g., Line, Scatter).
        /// </summary>
        public ChartType ChartType { get; set; } = ChartType.Line;

        /// <summary>
        /// Indicates whether to show the legend.
        /// </summary>
        public bool ShowLegend { get; set; } = true;

        /// <summary>
        /// The collection of axes in the chart.
        /// </summary>
        public AxisCollection Axes { get; init; } = new();
       
    }
}

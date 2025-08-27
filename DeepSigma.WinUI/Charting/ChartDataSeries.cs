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
    public class ChartDataSeries : ChartSeriesAbstract, IChartSeriesAbstract
    {
        /// <summary>
        /// Gets or sets the type of the chart series.
        /// </summary>
        public required DataChartType ChartType { get; set; }
    }
}

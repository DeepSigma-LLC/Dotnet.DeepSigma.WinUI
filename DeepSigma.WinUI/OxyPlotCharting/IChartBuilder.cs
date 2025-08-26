using DeepSigma.WinUI.Charting.Enum;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepSigma.WinUI.Charting;
using DeepSigma.WinUI.Charting.DataModels;

namespace DeepSigma.WinUI.OxyPlotCharting   
{
    /// <summary>
    /// Interface for building OxyPlot PlotModel from Chart specifications.
    /// </summary>
    public interface IChartBuilder
    {
        /// <summary>
        /// Gets the type of chart this builder supports.
        /// </summary>
        ChartType Type { get; }

        /// <summary>
        /// Builds an OxyPlot PlotModel based on the provided Chart specification.
        /// </summary>
        /// <param name="chart"></param>
        /// <returns></returns>
        PlotModel Build(Chart chart);
    }
}

using DeepSigma.WinUI.Charting.Enum;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Interfaces;

namespace DeepSigma.WinUI.OxyPlotCharting   
{
    /// <summary>
    /// Interface for building OxyPlot PlotModel from Chart specifications.
    /// </summary>
    internal interface ICategoricalChartBuilder
    {
        /// <summary>
        /// Gets the type of chart this builder supports.
        /// </summary>
        CategoricalChartType Type { get; }

        /// <summary>
        /// Builds an OxyPlot PlotModel based on the provided Chart specification.
        /// </summary>
        /// <param name="plot"></param>
        /// <param name="series"></param>
        /// <returns></returns>
        void AddSeries(PlotModel plot, IChartSeriesAbstract series);
    }
}

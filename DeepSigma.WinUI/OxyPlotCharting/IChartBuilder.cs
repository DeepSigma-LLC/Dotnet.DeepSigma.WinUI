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
    internal interface IChartBuilder
    {
        /// <summary>
        /// Gets the type of chart this builder supports.
        /// </summary>
        ChartSeriesType Type { get; }

        /// <summary>
        /// Builds an OxyPlot PlotModel based on the provided Chart specification.
        /// </summary>
        /// <param name="plot"></param>
        /// <param name="series"></param>
        /// <returns></returns>
        void AddSeries<D>(PlotModel plot, ChartSeries<D> series) where D: IDataModel;
    }
}

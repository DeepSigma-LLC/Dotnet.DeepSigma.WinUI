using DeepSigma.Charting.Enum;
using OxyPlot;
using DeepSigma.Charting.Interfaces;

namespace DeepSigma.WinUI.OxyPlotCharting;   

/// <summary>
/// Interface for building OxyPlot PlotModel from Chart specifications.
/// </summary>
internal interface IDataChartBuilder
{
    /// <summary>
    /// Gets the type of chart this builder supports.
    /// </summary>
    DataChartType Type { get; }

    /// <summary>
    /// Builds an OxyPlot PlotModel based on the provided Chart specification.
    /// </summary>
    /// <param name="plot"></param>
    /// <param name="series"></param>
    /// <returns></returns>
    void AddSeries(PlotModel plot, IChartSeriesAbstract series);
}

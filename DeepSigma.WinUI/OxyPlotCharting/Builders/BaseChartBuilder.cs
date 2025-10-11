using DeepSigma.Charting.Models;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeepSigma.WinUI.OxyPlotCharting.Builders;

internal abstract class BaseChartBuilder
{
    /// <summary>
    /// Converts data type of series.
    /// </summary>
    /// <typeparam name="V"></typeparam>
    /// <exception cref="InvalidCastException"></exception>
    protected static List<V> ConvertSeriesDataType<V>(List<IDataModel> data) where V : IDataModel
    {
        return data.Cast<V>().ToList();
    }
}

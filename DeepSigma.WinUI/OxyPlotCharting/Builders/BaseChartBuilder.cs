using DeepSigma.WinUI.Charting;
using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeepSigma.WinUI.OxyPlotCharting.Builders
{
    internal abstract class BaseChartBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <exception cref="InvalidCastException"></exception>
        protected static List<V> ConvertSeriesDataType<D, V>(List<D> data) where D : IDataModel where V : IDataModel
        {
            return data.Cast<V>().ToList();
        }
    }
}

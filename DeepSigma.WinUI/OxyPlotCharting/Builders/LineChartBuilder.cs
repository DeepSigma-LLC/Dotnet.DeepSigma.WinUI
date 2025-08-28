using DeepSigma.Charting.Models;
using DeepSigma.Charting.Enum;
using DeepSigma.Charting.Interfaces;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;

namespace DeepSigma.WinUI.OxyPlotCharting.Builders
{
    internal class LineChartBuilder : BaseChartBuilder, IDataChartBuilder
    {
        public DataChartType Type => DataChartType.Line;

        void IDataChartBuilder.AddSeries(PlotModel plot, IChartSeriesAbstract series)
        {
            LineSeries oxy_series = (LineSeries)OxyPlotUtilities.GetSeries(Type);

            oxy_series.Title = series.SeriesName;
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.Color = OxyPlotUtilities.GetOxyColor(series.Color);
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.XAxisKey = series.Axes[0].Key;
            oxy_series.YAxisKey = series.Axes[1].Key;

            LoadSeries(oxy_series, series.Data.GetAllDataPoints());
            plot.Series.Add(oxy_series);
        }

        private static void LoadSeries(LineSeries series, List<IDataModel> data)
        {
            List<XYData> converted_data = ConvertSeriesDataType<XYData>(data);
            foreach (XYData point in converted_data)
            {
                series.Points.Add(new DataPoint((double)point.X, (double)point.Y));
            }
        }

    }
}

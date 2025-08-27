using DeepSigma.WinUI.Charting;
using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.OxyPlotCharting.Builders
{
    internal class ScatterChartBuilder : BaseChartBuilder, IChartBuilder
    {
        public ChartSeriesType Type => ChartSeriesType.Scatter;

        void IChartBuilder.AddSeries<D>(PlotModel plot, ChartSeries<D> series)
        {
            ScatterSeries oxy_series = (ScatterSeries)OxyPlotUtilities.GetSeries(series.ChartSeriesType);

            oxy_series.Title = series.SeriesName;
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.MarkerFill = OxyPlotUtilities.GetOxyColor(series.Color);
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.XAxisKey = series.PrimaryAxis.Key;
            oxy_series.YAxisKey = series.SecondardyAxis.Key;

            LoadSeries(oxy_series, series.Data.GetAllDataPoints());

            plot.Series.Add(oxy_series);
        }

        private static void LoadSeries<D>(ScatterSeries series, List<D> data) where D : IDataModel
        {
            List<XYData> converted_data = ConvertSeriesDataType<D, XYData>(data);
            foreach (XYData item in converted_data)
            {
                series.Points.Add(new ScatterPoint((double)item.X, (double)item.Y));
            }
        }
    }
}

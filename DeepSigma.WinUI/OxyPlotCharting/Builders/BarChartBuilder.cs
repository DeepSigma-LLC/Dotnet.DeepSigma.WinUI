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
    internal class BarChartBuilder : BaseChartBuilder, IChartBuilder
    {
        public ChartSeriesType Type => ChartSeriesType.Bar;

        void IChartBuilder.AddSeries<D>(PlotModel plot, ChartSeries<D> series)
        {
            BarSeries oxy_series = (BarSeries)OxyPlotUtilities.GetSeries(series.ChartSeriesType);

            oxy_series.Title = series.SeriesName;
            oxy_series.FillColor = OxyPlotUtilities.GetOxyColor(series.Color);
            oxy_series.XAxisKey = series.PrimaryAxis.Key;
            oxy_series.YAxisKey = series.SecondardyAxis.Key;

            LoadSeries(oxy_series, series.Data.GetAllDataPoints());

            plot.Series.Add(oxy_series);
        }

        private static void LoadSeries<D>(BarSeries series, List<D> data) where D : IDataModel
        {
            List<CategoricalData> converted_data = ConvertSeriesDataType<D, CategoricalData>(data);
            for (int i = 0; i < data.Count; i++)
            {
                series.Items.Add(new BarItem { Value = (double)converted_data[i].Value, CategoryIndex = i });
            }
        }
    }
}

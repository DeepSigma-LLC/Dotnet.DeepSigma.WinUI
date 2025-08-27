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
    internal class PieChartBuilder : BaseChartBuilder, IChartBuilder
    {
        public ChartSeriesType Type => ChartSeriesType.Pie;

        void IChartBuilder.AddSeries<D>(PlotModel plot, ChartSeries<D> series)
        {
            PieSeries oxy_series = (PieSeries)OxyPlotUtilities.GetSeries(series.ChartSeriesType);

            oxy_series.Title = series.SeriesName;
            oxy_series.LabelField = series.PrimaryAxis.Key;
            oxy_series.ValueField = series.SecondardyAxis.Key;

            LoadSeries(oxy_series, series.Data.GetAllDataPoints());

            plot.Series.Add(oxy_series);
        }

        private static void LoadSeries<D>(PieSeries series, List<D> data) where D : IDataModel
        {
            List<CategoricalData> converted_data = ConvertSeriesDataType<D, CategoricalData>(data);
            foreach (CategoricalData item in converted_data)
            {
                series.Slices.Add(new PieSlice(item.Category, (double)item.Value)
                {
                    IsExploded = false,
                    //Fill = OxyPlotUtilities.GetOxyColor(Color.FromArgb(100 + i * 10, 100 + i * 10, 200))
                });
            }
        }

    }
}

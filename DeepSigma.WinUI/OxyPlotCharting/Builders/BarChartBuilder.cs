using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;
using DeepSigma.WinUI.Charting.Interfaces;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.OxyPlotCharting.Builders
{
    internal class BarChartBuilder : BaseChartBuilder, ICategoricalChartBuilder
    {
        public CategoricalChartType Type => CategoricalChartType.Bar;

        void ICategoricalChartBuilder.AddSeries(PlotModel plot, IChartSeriesAbstract series)
        {
            BarSeries oxy_series = (BarSeries)OxyPlotUtilities.GetSeries(Type);

            oxy_series.Title = series.SeriesName;
            oxy_series.FillColor = OxyPlotUtilities.GetOxyColor(series.Color);
            oxy_series.XAxisKey = series.Axes[0].Key;
            oxy_series.YAxisKey = series.Axes[1].Key;

            LoadSeries(oxy_series, series.Data.GetAllDataPoints());

            plot.Series.Add(oxy_series);
        }

        private static void LoadSeries(BarSeries series, List<IDataModel> data)
        {
            List<CategoricalData> converted_data = ConvertSeriesDataType<CategoricalData>(data);
            for (int i = 0; i < data.Count; i++)
            {
                series.Items.Add(new BarItem { Value = (double)converted_data[i].Value, CategoryIndex = i });
            }
        }
    }
}

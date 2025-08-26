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
        public ChartType Type => ChartType.Bar;

        protected override void AddSeries(PlotModel plot, Chart chart)
        {
            foreach (ChartSeries<CategoricalData> chart_series in chart.GetSeries<CategoricalData>())
            {
                BarSeries series = (BarSeries)OxyPlotUtilities.GetSeries(chart.ChartType);
                foreach (CategoricalData item in chart_series.DataPoints.GetAllDataPoints())
                {
                    LoadSeries(series, chart_series.DataPoints.GetAllDataPoints());
                }

                series.Title = chart_series.SeriesName;
                series.FillColor = OxyPlotUtilities.GetOxyColor(chart_series.Color);
                series.XAxisKey = "X";
                series.YAxisKey = "Y";

                plot.Series.Add(series);
            }
        }

        private static void LoadSeries(BarSeries series, List<CategoricalData> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                series.Items.Add(new BarItem { Value = (double)data[i].Value, CategoryIndex = i });
            }
        }
    }
}

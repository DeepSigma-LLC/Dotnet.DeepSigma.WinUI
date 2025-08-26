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
        public ChartType Type => ChartType.Scatter;

        protected override void AddSeries(PlotModel plot, Chart chart)
        {
            foreach (ChartSeries<XYData> chart_series in chart.GetSeries<XYData>())
            {
                ScatterSeries series = (ScatterSeries)OxyPlotUtilities.GetSeries(chart.ChartType);
                foreach (XYData item in chart_series.DataPoints.GetAllDataPoints())
                {
                    LoadSeries(series, chart_series.DataPoints.GetAllDataPoints());
                }

                series.Title = chart_series.SeriesName;
                series.MarkerType = MarkerType.Circle;
                series.MarkerFill = OxyPlotUtilities.GetOxyColor(chart_series.Color);
                series.MarkerType = MarkerType.Circle;
                series.XAxisKey = "X";
                series.YAxisKey = "Y";

                plot.Series.Add(series);
            }
        }

        private static void LoadSeries(ScatterSeries series, List<XYData> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                series.Points.Add(new ScatterPoint((double)data[i].X, (double)data[i].Y));
            }
        }
    }
}

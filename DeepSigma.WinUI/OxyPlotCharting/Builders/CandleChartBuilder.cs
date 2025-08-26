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
    internal class CandleChartBuilder : BaseChartBuilder, IChartBuilder
    {
        public ChartType Type => ChartType.CandleStick;

        protected override void AddSeries(PlotModel plot, Chart chart)
        {
            foreach (ChartSeries<CandleData> chart_series in chart.GetSeries<CandleData>())
            {
                CandleStickSeries series = (CandleStickSeries)OxyPlotUtilities.GetSeries(chart.ChartType);
                foreach (CandleData item in chart_series.DataPoints.GetAllDataPoints())
                {
                    LoadSeries(series, chart_series.DataPoints.GetAllDataPoints());
                }

                series.Title = chart_series.SeriesName;
                series.Color = OxyPlotUtilities.GetOxyColor(chart_series.Color);
                series.DecreasingColor = OxyColors.Red;
                series.IncreasingColor = OxyColors.Green;
                series.XAxisKey = "X";
                series.YAxisKey = "Y";

                plot.Series.Add(series);
            }
        }

        private static void LoadSeries(CandleStickSeries series, List<CandleData> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                series.Items.Add(new HighLowItem
                {
                    X = (double)data[i].X,
                    High = (double)data[i].High,
                    Low = (double)data[i].Low,
                    Open = (double)data[i].Open,
                    Close = (double)data[i].Close
                });
            }
        }
    }
}

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
    internal class BoxPlotChartBuilder : BaseChartBuilder, IChartBuilder
    {
        public ChartType Type => ChartType.BoxPlot;

        protected override void AddSeries(PlotModel plot, IChart<IAxis> chart)
        {
            foreach (ChartSeries<BoxPlotData> chart_series in chart.GetSeries<BoxPlotData>())
            {
                BoxPlotSeries series = (BoxPlotSeries)OxyPlotUtilities.GetSeries(chart.ChartType);
                foreach (BoxPlotData item in chart_series.DataPoints.GetAllDataPoints())
                {
                    LoadSeries(series, chart_series.DataPoints.GetAllDataPoints());
                }

                series.Title = chart_series.SeriesName;
                series.Fill = OxyPlotUtilities.GetOxyColor(chart_series.Color);
                series.XAxisKey = "X";
                series.YAxisKey = "Y";

                plot.Series.Add(series);
            }
        }

        private static void LoadSeries(BoxPlotSeries series, List<BoxPlotData> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                series.Items.Add(new BoxPlotItem(
                    x: (double)data[i].X,
                    lowerWhisker: (double)data[i].LowerWhisker,
                    boxBottom: (double)data[i].BoxBottom,
                    median: (double)data[i].Median,
                    boxTop: (double)data[i].BoxTop,
                    upperWhisker: (double)data[i].UpperWhisker
                ));
            }
        }


    }
}

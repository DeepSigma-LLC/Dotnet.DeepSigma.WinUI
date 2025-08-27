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
        public ChartSeriesType Type => ChartSeriesType.BoxPlot;

        void IChartBuilder.AddSeries<D>(PlotModel plot, ChartSeries<D> series)
        {
            BoxPlotSeries oxy_series = (BoxPlotSeries)OxyPlotUtilities.GetSeries(series.ChartSeriesType);

            oxy_series.Title = series.SeriesName;
            oxy_series.Fill = OxyPlotUtilities.GetOxyColor(series.Color);
            oxy_series.XAxisKey = series.PrimaryAxis.Key;
            oxy_series.YAxisKey = series.SecondardyAxis.Key;

            LoadSeries(oxy_series, series.Data.GetAllDataPoints());

            plot.Series.Add(oxy_series);
        }

        private static void LoadSeries<D>(BoxPlotSeries series, List<D> data) where D : IDataModel
        {
            List<BoxPlotData> converted_data = ConvertSeriesDataType<D, BoxPlotData>(data);

            foreach (BoxPlotData item in converted_data)
            {
                if (item.LowerWhisker > item.BoxBottom ||
                    item.BoxBottom > item.Median ||
                    item.Median > item.BoxTop ||
                    item.BoxTop > item.UpperWhisker)
                {
                    throw new ArgumentException("Invalid BoxPlotData: Ensure that LowerWhisker <= BoxBottom <= Median <= BoxTop <= UpperWhisker");
                }

                series.Items.Add(new BoxPlotItem(
                    x: (double)item.X,
                    lowerWhisker: (double)item.LowerWhisker,
                    boxBottom: (double)item.BoxBottom,
                    median: (double)item.Median,
                    boxTop: (double)item.BoxTop,
                    upperWhisker: (double)item.UpperWhisker
                ));
            }
        }


    }
}

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
    internal class AreaChartBuilder : BaseChartBuilder, IChartBuilder
    {
        public ChartSeriesType Type => ChartSeriesType.Area;

        void IChartBuilder.AddSeries<D>(PlotModel plot, ChartSeries<D> series)
        {
            AreaSeries oxy_series = (AreaSeries)OxyPlotUtilities.GetSeries(series.ChartSeriesType);

            oxy_series.Title = series.SeriesName;
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.MarkerFill = OxyPlotUtilities.GetOxyColor(series.Color);
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.XAxisKey = series.PrimaryAxis.Key;
            oxy_series.YAxisKey = series.SecondardyAxis.Key;

            LoadSeries(oxy_series, series.Data.GetAllDataPoints());
       
            plot.Series.Add(oxy_series);
        }

        private static void LoadSeries<D>(AreaSeries series, List<D> data) where D : IDataModel
        {
            List<XYData> converted_data = ConvertSeriesDataType<D, XYData>(data);
            foreach (XYData point in converted_data)
            {
                series.Points.Add(new DataPoint((double)point.X, (double)point.Y));
            }
        }

    }
}

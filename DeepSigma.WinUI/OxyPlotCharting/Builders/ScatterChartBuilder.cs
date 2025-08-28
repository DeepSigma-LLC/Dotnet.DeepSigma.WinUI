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
    internal class ScatterChartBuilder : BaseChartBuilder, IDataChartBuilder
    {
        public DataChartType Type => DataChartType.Scatter;

        void IDataChartBuilder.AddSeries(PlotModel plot, IChartSeriesAbstract series)
        {
            ScatterSeries oxy_series = (ScatterSeries)OxyPlotUtilities.GetSeries(Type);

            oxy_series.Title = series.SeriesName;
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.MarkerFill = OxyPlotUtilities.GetOxyColor(series.Color);
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.XAxisKey = series.Axes[0].Key;
            oxy_series.YAxisKey = series.Axes[1].Key;

            LoadSeries(oxy_series, series.Data.GetAllDataPoints());

            plot.Series.Add(oxy_series);
        }

        private static void LoadSeries(ScatterSeries series, List<IDataModel> data) 
        {
            List<XYData> converted_data = ConvertSeriesDataType<XYData>(data);
            foreach (XYData item in converted_data)
            {
                series.Points.Add(new ScatterPoint((double)item.X, (double)item.Y));
            }
        }
    }
}

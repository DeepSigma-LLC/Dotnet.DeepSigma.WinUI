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
    internal class StairStepChartBuilder : BaseChartBuilder, IDataChartBuilder
    {
        public DataChartType Type => DataChartType.StepLine;

        void IDataChartBuilder.AddSeries(PlotModel plot, IChartSeriesAbstract series)
        {
            StairStepSeries oxy_series = (StairStepSeries)OxyPlotUtilities.GetSeries(Type);

            oxy_series.Title = series.SeriesName;
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.Color = OxyPlotUtilities.GetOxyColor(series.Color);
            oxy_series.MarkerType = MarkerType.Circle;
            oxy_series.XAxisKey = series.PrimaryAxis.Key;
            oxy_series.YAxisKey = series.SecondardyAxis.Key;
            LoadSeries(oxy_series, series.Data.GetAllDataPoints());

            plot.Series.Add(oxy_series);
        }
        private static void LoadSeries(StairStepSeries series, List<IDataModel> data)
        {
            List<XYData> converted_data = ConvertSeriesDataType<XYData>(data);
            foreach (XYData item in converted_data)
            {
                series.Points.Add(new DataPoint((double)item.X, (double)item.Y));
            }
        }
    }
}

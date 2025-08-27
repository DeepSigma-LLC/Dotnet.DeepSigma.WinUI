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
        public ChartType Type => ChartType.Pie;

        protected override void AddSeries(PlotModel plot, IChart<IAxis> chart)
        {
            foreach (ChartSeries<CategoricalData> chart_series in chart.GetSeries<CategoricalData>())
            {
                PieSeries series = (PieSeries)OxyPlotUtilities.GetSeries(chart.ChartType);
                foreach (CategoricalData item in chart_series.DataPoints.GetAllDataPoints())
                {
                    LoadSeries(series, chart_series.DataPoints.GetAllDataPoints());
                }

                series.Title = chart_series.SeriesName;
                series.LabelField = "Category";
                series.ValueField = "Y";

                plot.Series.Add(series);
            }
        }

        private static void LoadSeries(PieSeries series, List<CategoricalData> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                series.Slices.Add(new PieSlice(data[i].Category, (double)data[i].Value)
                {
                    IsExploded = false,
                    //Fill = OxyPlotUtilities.GetOxyColor(Color.FromArgb(100 + i * 10, 100 + i * 10, 200))
                });
            }
        }

    }
}

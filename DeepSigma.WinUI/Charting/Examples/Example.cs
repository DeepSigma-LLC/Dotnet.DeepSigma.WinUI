using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DeepSigma.WinUI.Charting.Examples
{
    internal class Example
    {
        private void ExampleChartGeneration()
        {
            Chart2D chart = new Chart2D();
            chart.Title = "Sample Chart";
            chart.ShowLegend = true;

            Axis2D x_axis = new()
            {
                Title = "DateTime",
                Key = "X_Lables",
                AxisPosition = Chart2DAxisPosition.Bottom,
                AxisType = AxisType.DateTime,
                IsZoomEnabled = false,
                AxisFormatString = "MM-dd-yyyy"
            };
            chart.Axes.AddAxis(x_axis);

            Axis2D price_axis = new()
            {
                Title = "Price",
                Key = "Price",
                AxisPosition = Chart2DAxisPosition.Left,
                AxisType = AxisType.Linear,
                MajorGridlineStyle = ChartLineStyle.Dash,
                MinorGridlineStyle = ChartLineStyle.Dash,
                StartLocation = 0.25,
                EndLocation = 1,
                IsZoomEnabled = true,
            };
            chart.Axes.AddAxis(price_axis);

            Axis2D volume_axis = new()
            {
                Title = "Volume",
                Key = "Y",
                AxisPosition = Chart2DAxisPosition.Left,
                AxisType = AxisType.Linear,
                MajorGridlineStyle = ChartLineStyle.Dash,
                MinorGridlineStyle = ChartLineStyle.Dash,
                StartLocation = 0,
                EndLocation = 0.20,
                IsZoomEnabled = false
            };
            chart.Axes.AddAxis(volume_axis);

            List<XYData> line_data = [];
            line_data.Add(new(1, 3));
            line_data.Add(new(2, 4));
            line_data.Add(new(3, -1));
            line_data.Add(new(4, 10));
            line_data.Add(new(5, -3));
            line_data.Add(new(6, 3));
            line_data.Add(new(7, 6));
            line_data.Add(new(8, 9));


            List<CandleData> candle_data = new()
            {
                new CandleData(DateTime.Parse("1/1/2025"), 100, 110, 95, 94,10000, 12000),
                new CandleData(DateTime.Parse("1/2/2025"), 94, 108, 98, 99, 10000, 12000),
                new CandleData(DateTime.Parse("1/3/2025"), 100, 108, 92, 101, 12000, 11000),
                new CandleData(DateTime.Parse("1/4/2025"), 101, 112, 97, 110, 12500, 13000),
                new CandleData(DateTime.Parse("1/5/2025"), 110, 115, 105, 107, 11800, 13500),
                new CandleData(DateTime.Parse("1/6/2025"), 107, 113, 102, 111, 12200, 12800),
                new CandleData(DateTime.Parse("1/7/2025"), 111, 120, 109, 119, 14000, 15000),
                new CandleData(DateTime.Parse("1/8/2025"), 119, 122, 112, 115, 13500, 14500),
                new CandleData(DateTime.Parse("1/9/2025"), 115, 118, 108, 110, 12800, 13200),
                new CandleData(DateTime.Parse("1/10/2025"), 110, 117, 106, 114, 13000, 13800),
            };

            DataSeries<IDataModel> candle_Series = new();
            candle_Series.AddRange(candle_data);

            DataSeries<IDataModel> line_Series = new();
            line_Series.AddRange(line_data);

            ChartFinancialSeries fin_series = new()
            {
                Color = Color.Red,
                SeriesName = "S&P 500",
                ChartType = FinancialChartType.CandleStick,
                Data = candle_Series
            };
            fin_series.Axes.Add(0, x_axis);
            fin_series.Axes.Add(1, price_axis);

            ChartFinancialSeries vol_series = new()
            {
                Color = Color.Red,
                SeriesName = "S&P 500 Volume",
                ChartType = FinancialChartType.Volume,
                Data = candle_Series
            };
            vol_series.Axes.Add(0, x_axis);
            vol_series.Axes.Add(1, volume_axis);

            ChartDataSeries series = new()
            {
                Color = Color.Red,
                SeriesName = "S&P 500",
                ChartType = DataChartType.Line,
                Data = line_Series
            };


            chart.Series.Add(fin_series);
            chart.Series.Add(vol_series);

            var builder = ChartBuilderRegistry.CreateWithDefaults();
            PlotModel plot = builder.Build(chart);

            // Set the PlotModel to the custom Plot Control  (assuming you have a PlotView named myPlot) or a PlotView directly (from Oxyplot).
            //myPlot.SetPlotModel(plot);
        }
    }
}

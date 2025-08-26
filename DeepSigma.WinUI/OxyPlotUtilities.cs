using DeepSigma.WinUI.Charting.Enum;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Drawing;
using DeepSigma.WinUI.Charting; 

namespace DeepSigma.WinUI
{
    internal class OxyPlotUtilities
    {
        internal static PlotModel CreatePlot(Chart chart)
        {
            PlotModel plot = new()
            {
                Title = chart.Title,
                IsLegendVisible = chart.ShowLegend,
                Legends =
                {
                    new OxyPlot.Legends.Legend
                    {
                        LegendPosition = OxyPlot.Legends.LegendPosition.TopRight,
                        LegendPlacement = OxyPlot.Legends.LegendPlacement.Outside,
                        LegendOrientation = OxyPlot.Legends.LegendOrientation.Vertical,
                        LegendBorderThickness = 0
                    }
                }
            };
            return plot;
        }

        internal static void AddAxesToPlot(PlotModel plot, Chart chart)
        {
            foreach (DeepSigma.WinUI.Charting.Axis ax in chart.Axes.GetAllAxes())
            {
                var axis = OxyPlotUtilities.CreateAxes(ax);
                plot.Axes.Add(axis);
            }
        }

        /// <summary>
        /// Creates an OxyPlot axis based on the provided DeepSigma.WinUI.Charting.Axis configuration.
        /// </summary>
        /// <param name="chart_type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal static Series GetSeries(ChartType chart_type)
        {
            switch (chart_type)
            {
                case ChartType.Line: return new LineSeries();
                case ChartType.Bar: return new BarSeries();
                case ChartType.Pie: return new PieSeries();
                case ChartType.Scatter: return new ScatterSeries();
                case ChartType.Histogram: return new HistogramSeries();
                case ChartType.BoxPlot: return new BoxPlotSeries();
                case ChartType.Area: return new AreaSeries();
                case ChartType.StepLine: return new StairStepSeries();
                case ChartType.CandleStick: return new CandleStickSeries();
                case ChartType.CandleStickAndVolume: return new VolumeSeries();
                case ChartType.HeatMap: return new HeatMapSeries();
                case ChartType.Column: return new BarSeries();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Creates an OxyPlot axis based on the provided DeepSigma.WinUI.Charting.Axis configuration.
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        internal static OxyPlot.Axes.Axis CreateAxes(DeepSigma.WinUI.Charting.Axis axis)
        {
            OxyPlot.Axes.Axis oxy_axis = OxyPlotUtilities.CreateAxis(axis.AxisType);
            oxy_axis.Key = axis.Key;
            oxy_axis.Title = axis.Title;
            oxy_axis.MajorGridlineStyle = OxyPlotUtilities.ConvertLineStyle(axis.MajorGridlineStyle);
            oxy_axis.MinorGridlineStyle = OxyPlotUtilities.ConvertLineStyle(axis.MinorGridlineStyle);

            if (!double.IsNaN(axis.Minimum))
            {
                oxy_axis.Minimum = axis.Minimum;
            }

            if (!double.IsNaN(axis.Maximum))
            {
                oxy_axis.Maximum = axis.Maximum;
            }

            if (axis.AxisFormatString is not null)
            {
                oxy_axis.StringFormat = axis.AxisFormatString;
            }

            return oxy_axis;
        }

        /// <summary>
        /// Converts a ChartLineStyle to an OxyPlot LineStyle.
        /// </summary>
        /// <param name="lineStyle"></param>
        /// <returns></returns>
        internal static LineStyle ConvertLineStyle(ChartLineStyle lineStyle)
        {
            return lineStyle switch
            {
                ChartLineStyle.Solid => LineStyle.Solid,
                ChartLineStyle.Dash => LineStyle.Dash,
                ChartLineStyle.Dot => LineStyle.Dot,
                ChartLineStyle.DashDot => LineStyle.DashDot,
                ChartLineStyle.DashDashDot => LineStyle.DashDashDot,
                _ => LineStyle.Solid,
            };
        }

        /// <summary>
        /// Creates an OxyPlot axis based on the provided AxisType.
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal static OxyPlot.Axes.Axis CreateAxis(AxisType axis)
        {
            switch (axis)
            {
                case AxisType.Linear:
                    return new LinearAxis();
                case AxisType.Logarithmic:
                    return new LogarithmicAxis();
                case AxisType.DateTime:
                    return new DateTimeAxis();
                case AxisType.Categorical:
                    return new CategoryAxis();
                default:
                    throw new NotImplementedException($"Axis type {axis} is not supported.");
            };
        }

        /// <summary>
        /// Converts a System.Drawing.Color to an OxyPlot OxyColor.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        internal static OxyColor GetOxyColor(Color color)
        {
            return OxyColor.FromArgb(color.A, color.R, color.G, color.B);
        }

    }
}

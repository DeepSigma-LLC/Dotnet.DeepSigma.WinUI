using DeepSigma.WinUI.Charting.Enum;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Drawing;
using DeepSigma.WinUI.Charting;
using DeepSigma.WinUI.Charting.DataModels;

namespace DeepSigma.WinUI.OxyPlotCharting
{
    internal class OxyPlotUtilities
    {
        internal static PlotModel CreatePlot<D>(IChart<IAxis, D> chart) where D : IDataModel
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

        internal static void AddAxesToPlot<D>(PlotModel plot, IChart<IAxis, D> chart) where D : IDataModel
        {
            foreach (AxisAbstract ax in chart.Axes.GetAllAxes())
            {
                var axis = CreateAxes(ax);
                plot.Axes.Add(axis);
            }
        }

        /// <summary>
        /// Creates an OxyPlot axis based on the provided DeepSigma.WinUI.Charting.Axis configuration.
        /// </summary>
        /// <param name="chart_type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal static Series GetSeries(ChartSeriesType chart_type)
        {
            switch (chart_type)
            {
                case ChartSeriesType.Line: return new LineSeries();
                case ChartSeriesType.Bar: return new BarSeries();
                case ChartSeriesType.Pie: return new PieSeries();
                case ChartSeriesType.Scatter: return new ScatterSeries();
                case ChartSeriesType.Histogram: return new HistogramSeries();
                case ChartSeriesType.BoxPlot: return new BoxPlotSeries();
                case ChartSeriesType.Area: return new AreaSeries();
                case ChartSeriesType.StepLine: return new StairStepSeries();
                case ChartSeriesType.CandleStick: return new CandleStickSeries();
                case ChartSeriesType.CandleStickAndVolume: return new VolumeSeries();
                case ChartSeriesType.HeatMap: return new HeatMapSeries();
                case ChartSeriesType.Column: return new BarSeries();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Creates an OxyPlot axis based on the provided DeepSigma.WinUI.Charting.Axis configuration.
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        internal static Axis CreateAxes(AxisAbstract axis)
        {
            Axis oxy_axis = CreateAxis(axis.AxisType);
            oxy_axis.Key = axis.Key;
            oxy_axis.Title = axis.Title;
            oxy_axis.MajorGridlineStyle = ConvertLineStyle(axis.MajorGridlineStyle);
            oxy_axis.MinorGridlineStyle = ConvertLineStyle(axis.MinorGridlineStyle);

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
        internal static Axis CreateAxis(AxisType axis)
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

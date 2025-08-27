using DeepSigma.WinUI.Charting.Enum;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Drawing;
using DeepSigma.WinUI.Charting;
using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Interfaces;

namespace DeepSigma.WinUI.OxyPlotCharting
{
    internal class OxyPlotUtilities
    {
        internal static PlotModel CreatePlot<A>(IChart<A> chart) where A : IAxis
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

        internal static void AddAxesToPlot<A>(PlotModel plot, IChart<A> chart) where A : IAxis
        {
            foreach (A ax in chart.Axes.GetAllAxes())
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
        internal static Series GetSeries(DataChartType chart_type)
        {
            switch (chart_type)
            {
                case DataChartType.Line: return new LineSeries();
                case DataChartType.Scatter: return new ScatterSeries();
                case DataChartType.Histogram: return new HistogramSeries();
                case DataChartType.Area: return new AreaSeries();
                case DataChartType.StepLine: return new StairStepSeries();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Creates an OxyPlot axis based on the provided DeepSigma.WinUI.Charting.Axis configuration.
        /// </summary>
        /// <param name="chart_type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal static Series GetSeries(CategoricalChartType chart_type)
        {
            switch (chart_type)
            {
                case CategoricalChartType.Bar: return new BarSeries();
                case CategoricalChartType.Pie: return new PieSeries();
                case CategoricalChartType.Column: return new BarSeries();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Creates an OxyPlot axis based on the provided DeepSigma.WinUI.Charting.Axis configuration.
        /// </summary>
        /// <param name="chart_type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal static Series GetSeries(FinancialChartType chart_type)
        {
            switch (chart_type)
            {
                case FinancialChartType.CandleStick: return new CandleStickSeries();
                case FinancialChartType.CandleStickAndVolume: return new VolumeSeries();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Creates an OxyPlot axis based on the provided DeepSigma.WinUI.Charting.Axis configuration.
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        internal static Axis CreateAxes<A>(A axis) where A : notnull, IAxis
        {
            Axis oxy_axis = CreateAxis(axis.AxisType);
            oxy_axis.Key = axis.Key;
            oxy_axis.Title = axis.Title;
            oxy_axis.MajorGridlineStyle = ConvertLineStyle(axis.MajorGridlineStyle);
            oxy_axis.MinorGridlineStyle = ConvertLineStyle(axis.MinorGridlineStyle);

            Axis2D? axis2D = axis as Axis2D;
            if (axis2D is not null)
            {
                oxy_axis.Position = ConvertAxisPosition(axis2D.AxisPosition);
            }


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

        private static AxisPosition ConvertAxisPosition(Chart2DAxisPosition position)
        {
            return position switch
            {
                Chart2DAxisPosition.Left => AxisPosition.Left,
                Chart2DAxisPosition.Right => AxisPosition.Right,
                Chart2DAxisPosition.Top => AxisPosition.Top,
                Chart2DAxisPosition.Bottom => AxisPosition.Bottom,
                _ => throw new NotImplementedException($"Axis position {position} is not supported.")
            };
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

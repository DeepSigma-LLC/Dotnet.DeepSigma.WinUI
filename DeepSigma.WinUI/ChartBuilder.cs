using System;
using System.Collections.Generic;
using OxyPlot;
using DeepSigma.Charting.Enum;
using DeepSigma.Charting;
using DeepSigma.WinUI.OxyPlotCharting.Builders;
using DeepSigma.WinUI.OxyPlotCharting;
using DeepSigma.Charting.Interfaces;

namespace DeepSigma.WinUI
{
    /// <summary>
    /// Registry for chart builders that can create PlotModel instances from ChartSpec specifications.
    /// </summary>
    public sealed class ChartBuilderRegistry
    {
        private readonly Dictionary<DataChartType, IDataChartBuilder> _builders = new();

        private readonly Dictionary<CategoricalChartType, ICategoricalChartBuilder> _category_builders = new();

        private readonly Dictionary<FinancialChartType, IFinancialChartBuilder> _finance_builders = new();

        /// <summary>
        /// Registers a new chart builder for a specific ChartType.
        /// </summary>
        /// <param name="builder"></param>
        internal void Register(IDataChartBuilder builder) => _builders[builder.Type] = builder;

        /// <summary>
        /// Registers a new chart builder for a specific ChartType.
        /// </summary>
        /// <param name="builder"></param>
        internal void Register(ICategoricalChartBuilder builder) => _category_builders[builder.Type] = builder;

        /// <summary>
        /// Registers a new chart builder for a specific ChartType.
        /// </summary>
        /// <param name="builder"></param>
        internal void Register(IFinancialChartBuilder builder) => _finance_builders[builder.Type] = builder;

        /// <summary>
        /// Builds a PlotModel based on the provided Chart specification.
        /// </summary>
        /// <param name="chart"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public PlotModel Build<A>(IChart<A> chart) where A : IAxis
        {
            PlotModel plot = OxyPlotUtilities.CreatePlot(chart);
            OxyPlotUtilities.AddAxesToPlot(plot, chart, chart.GetCategoricalLabels());
            foreach (IChartSeriesAbstract series in chart.GetSeries())
            {
                switch (series)
                {
                    case ChartDataSeries data:
                        if (!_builders.TryGetValue(data.ChartType, out var builder))
                        {
                            throw new InvalidOperationException($"No builder registered for {data.ChartType}");
                        }
                        builder.AddSeries(plot, series);
                        break;
                    case ChartCategoricalSeries data:
                        if (!_category_builders.TryGetValue(data.ChartType, out var builder_category))
                        {
                            throw new InvalidOperationException($"No builder registered for {data.ChartType}");
                        }
                        builder_category.AddSeries(plot, series);
                        break;
                    case ChartFinancialSeries data:
                        if (!_finance_builders.TryGetValue(data.ChartType, out var builder_finance))
                        {
                            throw new InvalidOperationException($"No builder registered for {data.ChartType}");
                        }
                        builder_finance.AddSeries(plot, series);
                        break;
                    default:
                        throw new NotSupportedException(series.GetType().Name);
                }

            }
            return plot;
        }

        /// <summary>
        /// Creates a ChartBuilderRegistry pre-populated with default chart builders.
        /// </summary>
        /// <returns></returns>
        public static ChartBuilderRegistry CreateWithDefaults()
        {
            var reg = new ChartBuilderRegistry();
            reg.Register(new LineChartBuilder());
            reg.Register(new BarChartBuilder());
            reg.Register(new ScatterChartBuilder());
            reg.Register(new AreaChartBuilder());
            reg.Register(new StairStepChartBuilder());
            reg.Register(new PieChartBuilder());
            reg.Register(new CandleChartBuilder());
            reg.Register(new VolumeChartBuilder());
            return reg;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using DeepSigma.WinUI.Charting.Enum;
using DeepSigma.WinUI.Charting;
using DeepSigma.WinUI.OxyPlotCharting.Builders;
using DeepSigma.WinUI.OxyPlotCharting;
using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Interfaces;

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
            OxyPlotUtilities.AddAxesToPlot(plot, chart);
            foreach (IChartSeriesAbstract<IDataModel> series in chart.GetSeries())
            {
                if(series.GetType() == typeof(ChartDataSeries))
                {
                    ChartDataSeries casted_series = (ChartDataSeries)series;
                    if (!_builders.TryGetValue(casted_series.ChartType, out var builder))
                    {
                        throw new InvalidOperationException($"No builder registered for {casted_series.ChartType}");
                    }

                    builder.AddSeries(plot, series);
                }
                else if (series.GetType() == typeof(ChartCategoricalSeries))
                {
                    ChartCategoricalSeries casted_series = (ChartCategoricalSeries)series;
                    if (!_category_builders.TryGetValue(casted_series.ChartType, out var builder))
                    {
                        throw new InvalidOperationException($"No builder registered for {casted_series.ChartType}");
                    }

                    builder.AddSeries(plot, series);
                }
                else if (series.GetType() == typeof(ChartFinancialSeries))
                {
                    ChartFinancialSeries casted_series = (ChartFinancialSeries)series;
                    if (!_finance_builders.TryGetValue(casted_series.ChartType, out var builder))
                    {
                        throw new InvalidOperationException($"No builder registered for {casted_series.ChartType}");
                    }

                    builder.AddSeries(plot, series);
                }
                else
                {
                    throw new NotImplementedException("Chart series build is not yet implemented.");
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
            reg.Register(new CandleChartBuilder());
            reg.Register(new CandleWithVolumeChartBuilder());
            reg.Register(new AreaChartBuilder());
            reg.Register(new StairStepChartBuilder());
            reg.Register(new PieChartBuilder());
            return reg;
        }
    }
}

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

namespace DeepSigma.WinUI
{
    /// <summary>
    /// Registry for chart builders that can create PlotModel instances from ChartSpec specifications.
    /// </summary>
    public sealed class ChartBuilderRegistry
    {
        private readonly Dictionary<ChartSeriesType, IChartBuilder> _builders = new();

        /// <summary>
        /// Registers a new chart builder for a specific ChartType.
        /// </summary>
        /// <param name="builder"></param>
        internal void Register(IChartBuilder builder) => _builders[builder.Type] = builder;

        /// <summary>
        /// Builds a PlotModel based on the provided Chart specification.
        /// </summary>
        /// <param name="chart"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public PlotModel Build<D>(IChart<IAxis, D> chart) where D : IDataModel
        {
            PlotModel plot = OxyPlotUtilities.CreatePlot(chart);
            OxyPlotUtilities.AddAxesToPlot(plot, chart);
            foreach (ChartSeries<D> series in chart.GetSeries())
            {
                if (!_builders.TryGetValue(series.ChartSeriesType, out var builder))
                {
                    throw new InvalidOperationException($"No builder registered for {series.ChartSeriesType}");
                }
                builder.AddSeries(plot, series);
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
            reg.Register(new BoxPlotChartBuilder());
            return reg;
        }
    }
}

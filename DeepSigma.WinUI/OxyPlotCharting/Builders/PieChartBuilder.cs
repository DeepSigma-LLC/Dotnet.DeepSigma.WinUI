using DeepSigma.Charting.Models;
using DeepSigma.Charting.Enum;
using DeepSigma.Charting.Interfaces;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;

namespace DeepSigma.WinUI.OxyPlotCharting.Builders;

internal class PieChartBuilder : BaseChartBuilder, ICategoricalChartBuilder
{
    public CategoricalChartType Type => CategoricalChartType.Pie;

    void ICategoricalChartBuilder.AddSeries(PlotModel plot, IChartSeriesAbstract series)
    {
        PieSeries oxy_series = (PieSeries)OxyPlotUtilities.GetSeries(Type);

        oxy_series.Title = series.SeriesName;
        oxy_series.LabelField = series.Axes[0].Key;
        oxy_series.ValueField = series.Axes[1].Key;

        LoadSeries(oxy_series, series.Data.GetAllDataPoints());

        plot.Series.Add(oxy_series);
    }

    private static void LoadSeries(PieSeries series, List<IDataModel> data)
    {
        List<CategoricalData> converted_data = ConvertSeriesDataType<CategoricalData>(data);
        foreach (CategoricalData item in converted_data)
        {
            series.Slices.Add(new PieSlice(item.Category, (double)item.Value)
            {
                IsExploded = false,
                //Fill = OxyPlotUtilities.GetOxyColor(Color.FromArgb(100 + i * 10, 100 + i * 10, 200))
            });
        }
    }

}

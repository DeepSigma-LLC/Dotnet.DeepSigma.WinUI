using DeepSigma.Charting.Models;
using DeepSigma.Charting.Enum;
using DeepSigma.Charting.Interfaces;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;

namespace DeepSigma.WinUI.OxyPlotCharting.Builders;

internal class VolumeChartBuilder : BaseChartBuilder, IFinancialChartBuilder
{
    public FinancialSeriesChartType Type => FinancialSeriesChartType.Volume;

    void IFinancialChartBuilder.AddSeries(PlotModel plot, IChartSeriesAbstract series)
    {
        VolumeSeries volume_series = (VolumeSeries)OxyPlotUtilities.GetSeries(Type);
        volume_series.VolumeStyle = VolumeStyle.PositiveNegative;
        volume_series.XAxisKey = series.Axes[0].Key;
        volume_series.YAxisKey = series.Axes[1].Key;

        LoadSeries(volume_series, series.Data.GetAllDataPoints());

        plot.Series.Add(volume_series);
    }

    private static void LoadSeries(VolumeSeries series, List<IDataModel> data)
    {
        List<CandleData> converted_data = ConvertSeriesDataType<CandleData>(data);
        foreach (CandleData item in converted_data)
        {
            series.Items.Add(new OhlcvItem
            {
                X = item.TimeStamp.ToOADate(),
                High = (double)item.High,
                Low = (double)item.Low,
                Open = (double)item.Open,
                Close = (double)item.Close,
                BuyVolume = (double)item.BuyVolume,
                SellVolume = (double)item.SellVolume
            });
        }
    }
}

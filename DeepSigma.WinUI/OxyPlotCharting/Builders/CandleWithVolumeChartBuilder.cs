using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Enum;
using DeepSigma.WinUI.Charting.Interfaces;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.OxyPlotCharting.Builders
{
    internal class CandleWithVolumeChartBuilder : BaseChartBuilder, IFinancialChartBuilder
    {
        public FinancialChartType Type => FinancialChartType.CandleStickAndVolume;

        void IFinancialChartBuilder.AddSeries<D>(PlotModel plot, IChartSeriesAbstract<D> series)
        {
            VolumeSeries oxy_series = (VolumeSeries)OxyPlotUtilities.GetSeries(Type);

            oxy_series.Title = series.SeriesName;
            oxy_series.VolumeStyle = VolumeStyle.PositiveNegative;
            oxy_series.XAxisKey = series.PrimaryAxis.Key;
            oxy_series.YAxisKey = series.SecondardyAxis.Key;

            LoadSeries(oxy_series, series.Data.GetAllDataPoints());

            plot.Series.Add(oxy_series);
        }

        private static void LoadSeries<D>(VolumeSeries series, List<D> data) where D : IDataModel
        {
            List<CandleData> converted_data = ConvertSeriesDataType<D, CandleData>(data);
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
}

using DeepSigma.WinUI.Charting.DataModels;
using System.Drawing;

namespace DeepSigma.WinUI.Charting.Interfaces
{
    public interface IChartSeriesAbstract
    {
        Color Color { get; set; }
        DataSeries<IDataModel> Data { get; set; }
        bool Interpolated { get; set; }
        IAxis PrimaryAxis { get; set; }
        IAxis SecondardyAxis { get; set; }
        string SeriesName { get; set; }
        IAxis? TertiaryAxis { get; set; }
    }
}
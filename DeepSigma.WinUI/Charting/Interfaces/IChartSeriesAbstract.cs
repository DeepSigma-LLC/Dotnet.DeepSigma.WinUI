using DeepSigma.WinUI.Charting.DataModels;
using System.Collections.Generic;
using System.Drawing;

namespace DeepSigma.WinUI.Charting.Interfaces
{
    public interface IChartSeriesAbstract
    {
        Color Color { get; set; }
        DataSeries<IDataModel> Data { get; set; }
        bool Interpolated { get; set; }
        string SeriesName { get; set; }
        SortedList<int, IAxis> Axes {get;set;}
    }
}
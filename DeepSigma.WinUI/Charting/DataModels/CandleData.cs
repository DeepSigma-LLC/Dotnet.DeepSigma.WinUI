using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.DataModels
{
    public class CandleData : IDataModel
    {
        public decimal X { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal BuyVolume { get; set; }
        public decimal SellVolume { get; set; }
        public CandleData() { }
        public CandleData(decimal x, decimal open, decimal high, decimal low, decimal close, decimal buyVolume, decimal sellVolume)
        {
            X = x;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            BuyVolume = buyVolume;
            SellVolume = sellVolume;
        }
    }
}

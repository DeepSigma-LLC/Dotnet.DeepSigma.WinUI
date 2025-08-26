using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.DataModels
{
    public class CandleData : IDataModel
    {
        public DateTime TimeStamp { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal BuyVolume { get; set; }
        public decimal SellVolume { get; set; }
        public CandleData() { }
        public CandleData(DateTime time_stamp, decimal open, decimal high, decimal low, decimal close, decimal buyVolume, decimal sellVolume)
        {
            TimeStamp = time_stamp;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            BuyVolume = buyVolume;
            SellVolume = sellVolume;
        }
    }
}

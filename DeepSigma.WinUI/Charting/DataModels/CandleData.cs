using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.DataModels
{
    /// <summary>
    /// Represents a data model for candlestick charts.
    /// </summary>
    public class CandleData : IDataModel
    {
        /// <summary>
        /// The timestamp of the candle.
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// The opening price of the candle.
        /// </summary>
        public decimal Open { get; set; }
        /// <summary>
        /// The highest price of the candle.
        /// </summary>
        public decimal High { get; set; }
        /// <summary>
        /// The lowest price of the candle.
        /// </summary>
        public decimal Low { get; set; }
        /// <summary>
        /// The closing price of the candle.
        /// </summary>
        public decimal Close { get; set; }
        /// <summary>
        /// The buy volume of the candle.
        /// </summary>
        public decimal BuyVolume { get; set; }
        /// <summary>
        /// The sell volume of the candle.
        /// </summary>
        public decimal SellVolume { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CandleData"/> class.
        /// </summary>
        public CandleData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CandleData"/> class with specified values.
        /// </summary>
        /// <param name="time_stamp"></param>
        /// <param name="open"></param>
        /// <param name="high"></param>
        /// <param name="low"></param>
        /// <param name="close"></param>
        /// <param name="buyVolume"></param>
        /// <param name="sellVolume"></param>
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

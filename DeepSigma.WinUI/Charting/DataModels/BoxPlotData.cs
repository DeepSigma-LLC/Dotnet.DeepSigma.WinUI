using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.DataModels
{
    public class BoxPlotData : IDataModel
    {
        public decimal X { get; set; }
        public decimal LowerWhisker { get; set; }
        public decimal BoxBottom { get; set; }
        public decimal Median { get; set; }
        public decimal BoxTop { get; set; }
        public decimal UpperWhisker { get; set; }
    }
}

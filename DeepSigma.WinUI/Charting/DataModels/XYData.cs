using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.DataModels
{
    public class XYData : IDataModel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public XYData() { }
        public XYData(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}

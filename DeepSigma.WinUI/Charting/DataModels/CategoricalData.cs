using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.DataModels
{
    public class CategoricalData : IDataModel
    {
        public string Category { get; set; }
        public double Value { get; set; }

        public CategoricalData() { }
        public CategoricalData(string category, double value)
        {
            Category = category;
            Value = value;
        }
    }
}

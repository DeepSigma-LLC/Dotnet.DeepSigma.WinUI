using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.DataModels
{
    /// <summary>
    /// Represents a data model for categorical data points.
    /// </summary>
    public class CategoricalData : IDataModel
    {
        /// <summary>
        /// The category label of the data point.
        /// </summary>
        public string? Category { get; set; }
        /// <summary>
        /// The numerical value associated with the category.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoricalData"/> class.
        /// </summary>
        public CategoricalData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoricalData"/> class with specified values.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="value"></param>
        public CategoricalData(string category, double value)
        {
            Category = category;
            Value = value;
        }
    }
}

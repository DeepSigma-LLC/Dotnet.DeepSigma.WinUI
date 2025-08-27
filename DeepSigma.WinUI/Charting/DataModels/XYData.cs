using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.DataModels
{
    /// <summary>
    /// Represents a data model for XY data points.
    /// </summary>
    public class XYData : IDataModel
    {
        /// <summary>
        /// The X coordinate of the data point.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The Y coordinate of the data point.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XYData"/> class.
        /// </summary>
        public XYData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="XYData"/> class with specified values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public XYData(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}

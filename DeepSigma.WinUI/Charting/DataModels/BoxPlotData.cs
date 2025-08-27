using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.DataModels
{
    /// <summary>
    /// Represents a data model for box plot charts.
    /// </summary>
    public class BoxPlotData : IDataModel
    {
        /// <summary>
        /// The current observation of the box plot.
        /// </summary>
        public decimal X { get; set; }
        /// <summary>
        /// The lower whisker value of the box plot.
        /// </summary>
        public decimal LowerWhisker { get; set; }
        /// <summary>
        /// The bottom value of the box in the box plot.
        /// </summary>
        public decimal BoxBottom { get; set; }
        /// <summary>
        /// The median value of the box plot.
        /// </summary>
        public decimal Median { get; set; }
        /// <summary>
        /// The top value of the box in the box plot.
        /// </summary>
        public decimal BoxTop { get; set; }
        /// <summary>
        /// The upper whisker value of the box plot.
        /// </summary>
        public decimal UpperWhisker { get; set; }
    }
}

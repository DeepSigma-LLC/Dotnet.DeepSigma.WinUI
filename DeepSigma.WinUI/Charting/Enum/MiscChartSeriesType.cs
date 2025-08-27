using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.Enum
{
    /// <summary>
    /// Defines the type of chart to be rendered.
    /// </summary>
    public enum MiscChartSeriesType
    {
        /// <summary>
        /// A heatmap, which is a data visualization technique that shows the magnitude of a phenomenon as color in two dimensions.
        /// </summary>
        HeatMap,
        /// <summary>
        /// A box plot, which is a standardized way of displaying the distribution of data based on a five-number summary.
        /// </summary>
        BoxPlot,
        /// <summary>
        /// A polar chart, which is a circular chart that plots data points in terms of angles and distances from a central point.
        /// </summary>
        Polar
    }
}

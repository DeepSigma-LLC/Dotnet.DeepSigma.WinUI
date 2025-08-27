using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.Enum
{
    /// <summary>
    /// Defines the types of category charts available.
    /// </summary>
    public enum CategoricalChartType
    {
        /// <summary>
        /// A bar chart, which represents data with rectangular bars with lengths proportional to the values they represent.
        /// </summary>
        Bar,
        /// <summary>
        /// A column chart, which is similar to a bar chart but with vertical bars.
        /// </summary>
        Column,
        /// <summary>
        /// A pie chart, which is a circular statistical graphic divided into slices to illustrate numerical proportions.
        /// </summary>
        Pie,
        /// <summary>
        /// A donut chart, which is similar to a pie chart but with a blank center.
        /// </summary>
        Donut,
        /// <summary>
        /// A radar chart, which is a graphical method of displaying multivariate data in the form of a two-dimensional chart.
        /// </summary>
        Radar,
        /// <summary>
        /// A gauge chart, which is used to display a single data point within a range, often resembling a speedometer.
        /// </summary>
        Gauge,
    }
}

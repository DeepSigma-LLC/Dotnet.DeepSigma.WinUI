using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.Enum
{
    /// <summary>
    /// Defines the type of XY chart to be rendered.
    /// </summary>
    public enum DataChartType
    {
        /// <summary>
        /// A line chart, which displays information as a series of data points connected by straight line segments.
        /// </summary>
        Line,
        /// <summary>
        /// A step line chart, which displays information as a series of data points connected by step-like segments.
        /// </summary>
        StepLine,
        /// <summary>
        /// A spline chart, which displays information as a series of data points connected by smooth curves.
        /// </summary>
        Spline,
        /// <summary>
        /// An area chart, which is similar to a line chart but with the area below the line filled in.
        /// </summary>
        Area,
        /// <summary>
        /// A scatter chart, which uses Cartesian coordinates to display values for typically two variables for a set of data.
        /// </summary>
        Scatter,
        /// <summary>
        /// A gauge chart, which is used to display a single data point within a range, often resembling a speedometer.
        /// </summary>
        Gauge,
        /// <summary>
        /// A histogram, which is an approximate representation of the distribution of numerical data.
        /// </summary>
        Histogram,
    }
}

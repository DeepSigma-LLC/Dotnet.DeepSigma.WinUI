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
    public enum ChartType
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
        /// A scatter chart, which uses Cartesian coordinates to display values for typically two variables for a set of data.
        /// </summary>
        Scatter,
        /// <summary>
        /// An area chart, which is similar to a line chart but with the area below the line filled in.
        /// </summary>
        Area,
        /// <summary>
        /// A histogram, which is an approximate representation of the distribution of numerical data.
        /// </summary>
        Histogram,
        /// <summary>
        /// A bubble chart, which is a type of chart that displays three dimensions of data.
        /// </summary>
        Bubble,
        /// <summary>
        /// A radar chart, which is a graphical method of displaying multivariate data in the form of a two-dimensional chart.
        /// </summary>
        Radar,
        /// <summary>
        /// A heatmap, which is a data visualization technique that shows the magnitude of a phenomenon as color in two dimensions.
        /// </summary>
        HeatMap,
        /// <summary>
        /// A box plot, which is a standardized way of displaying the distribution of data based on a five-number summary.
        /// </summary>
        BoxPlot,
        /// <summary>
        /// A candlestick chart, which is a style of financial chart used to describe price movements of a security, derivative, or currency.
        /// </summary>
        CandleStick,
        /// <summary>
        /// A candlestick chart combined with volume bars, which shows price movements along with trading volume.
        /// </summary>
        CandleStickAndVolume,
        /// <summary>
        /// A gauge chart, which is used to display a single data point within a range, often resembling a speedometer.
        /// </summary>
        Gauge,
        /// <summary>
        /// A polar chart, which is a circular chart that plots data points in terms of angles and distances from a central point.
        /// </summary>
        Polar
    }
}

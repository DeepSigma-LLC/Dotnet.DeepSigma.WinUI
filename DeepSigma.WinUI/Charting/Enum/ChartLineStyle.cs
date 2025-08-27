using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.Enum
{
    /// <summary>
    /// Defines the style of lines used in charts.
    /// </summary>
    public enum ChartLineStyle
    {
        /// <summary>
        /// A solid line with no breaks.
        /// </summary>
        Solid,
        /// <summary>
        /// A dashed line with regular breaks.
        /// </summary>
        Dash,
        /// <summary>
        /// A dotted line with small dots.
        /// </summary>
        Dot,
        /// <summary>
        /// A line with alternating dashes and dots.
        /// </summary>
        DashDot,
        /// <summary>
        /// A line with two dashes followed by a dot.
        /// </summary>
        DashDashDot
    }
}

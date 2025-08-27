using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting.Enum
{
    /// <summary>
    /// Defines the type of axis used in charts.
    /// </summary>
    public enum AxisType
    {
        /// <summary>
        /// A linear axis where values increase uniformly.
        /// </summary>
        Linear,
        /// <summary>
        /// A logarithmic axis where values increase exponentially.
        /// </summary>
        Logarithmic,
        /// <summary>
        /// A date-time axis for representing time-based data.
        /// </summary>
        DateTime,
        /// <summary>
        /// A categorical axis for discrete categories.
        /// </summary>
        Categorical
    }
}

using DeepSigma.WinUI.Charting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// A 3D axis for charts, extending the abstract axis functionality.
    /// </summary>
    public class Axis3D : AxisAbstract
    {
        /// <summary>
        /// Gets or sets the type of the 3D axis.
        /// </summary>
        public Chart3DAxis Axis { get; set; }
    }
}

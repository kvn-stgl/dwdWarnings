using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwdWarnings.Model
{
    public class WarningResult
    {
        /// <summary>
        /// List of actual Warnings
        /// </summary>
        public IList<Warning> Warnings { get; set; }

        /// <summary>
        /// Last Update Time
        /// </summary>
        public DateTime LastUpdate { get; set; }
    }
}

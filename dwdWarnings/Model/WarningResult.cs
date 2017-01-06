using System;
using System.Collections.Generic;

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

        public override string ToString()
        {
            return string.Format("[{0} Warnings, {1} Last Update]", Warnings.Count, LastUpdate.ToString());
        }
    }
}

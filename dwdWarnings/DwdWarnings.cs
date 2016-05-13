using dwdWarnings.Model;
using dwdWarnings.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwdWarnings
{
    public class Warnings
    {
        /// <summary>
        /// Return a list of warnings from the DWD (Deutscher Wetterdienst)
        /// </summary>
        /// <param name="id">Area ID</param>
        /// <returns>List of warnings</returns>
        public static WarningResult GetWarningsById(int id)
        {
            var result = GetWarnings();
            result.Warnings = result.Warnings.Where(_ => _.AreaId == id).ToList();

            return result;
        }

        /// <summary>
        /// Return a list of warnings from the DWD (Deutscher Wetterdienst)
        /// </summary>
        /// <param name="county">Region Name</param>
        /// <returns>List of warnings</returns>
        public static WarningResult GetWarningsByRegionName(string county)
        {
            var result = GetWarnings();
            result.Warnings = result.Warnings.Where(_ => _.RegionName == county).ToList();
            
            return result;
        }

        private static WarningResult GetWarnings()
        {
            try
            {
                WarningResult warnings = Deserializer.GetWarnings();
                return warnings;
            }
            catch (Exception ex)
            {
                throw new DwdException("Error receiving DWD data", ex);
            }
        }
    }
}

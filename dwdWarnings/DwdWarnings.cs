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
        public static IList<Warning> GetWarningsById(int id)
        {
            IList<Warning> warnings = GetWarnings();
            warnings = warnings.Where(_ => _.AreaId == id).ToList();

            return warnings;
        }

        /// <summary>
        /// Return a list of warnings from the DWD (Deutscher Wetterdienst)
        /// </summary>
        /// <param name="county">Region Name</param>
        /// <returns>List of warnings</returns>
        public static IList<Warning> GetWarningsByRegionName(string county)
        {
            IList<Warning> warnings = GetWarnings();
            warnings = warnings.Where(_ => _.RegionName == county).ToList();
            
            return warnings;
        }

        private static IList<Warning> GetWarnings()
        {
            try
            {
                IList<Warning> warnings = Deserializer.GetWarnings();
                return warnings;
            }
            catch (Exception ex)
            {
                throw new DwdException("Error receiving DWD data", ex);
            }
        }
    }
}

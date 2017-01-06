using dwdWarnings.Model;
using dwdWarnings.Util;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dwdWarnings
{
    public class Warnings
    {
        /// <summary>
        /// Return a list of warnings from the DWD (Deutscher Wetterdienst) asynchronously.
        /// </summary>
        /// <param name="id">Area ID</param>
        /// <returns>List of warnings</returns>
        public static async Task<WarningResult> GetWarningsByIdAsync(int id)
        {
            WarningResult result = await GetWarningsAsync();
            result.Warnings = result.Warnings.Where(_ => _.AreaId == id).ToList();

            return result;
        }

        /// <summary>
        /// Return a list of warnings from the DWD (Deutscher Wetterdienst) asynchronously.
        /// </summary>
        /// <param name="county">Region Name</param>
        /// <returns>List of warnings</returns>
        public static async Task<WarningResult> GetWarningsByRegionNameAsync(string county)
        {
            WarningResult result = await GetWarningsAsync();
            result.Warnings = result.Warnings.Where(_ => _.RegionName == county).ToList();

            return result;
        }

        /// <summary>
        /// Return a list of warnings from the DWD (Deutscher Wetterdienst).
        /// </summary>
        /// <param name="id">Area ID</param>
        /// <returns>List of warnings</returns>
        public static WarningResult GetWarningsById(int id)
        {
            Task<WarningResult> result = GetWarningsByIdAsync(id);
            return result.Result;
        }

        /// <summary>
        /// Return a list of warnings from the DWD (Deutscher Wetterdienst).
        /// </summary>
        /// <param name="county">Region Name</param>
        /// <returns>List of warnings</returns>
        public static WarningResult GetWarningsByRegionName(string county)
        {
            Task<WarningResult> result = GetWarningsByRegionNameAsync(county);
            return result.Result;
        }

        private static async Task<WarningResult> GetWarningsAsync()
        {
            try
            {
                WarningResult warnings = await Deserializer.GetWarningsAsync();
                return warnings;
            }
            catch (Exception ex)
            {
                throw new DwdException("Error receiving DWD data", ex);
            }
        }
    }
}

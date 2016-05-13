using dwdWarnings.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwdWarnings.Util
{
    internal class Deserializer
    {
        private static DateTime UnixToDatetime(string unix) 
        {
            long timestamp = 0;
            if (long.TryParse(unix, out timestamp))
            {
                DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                return dateTime.AddMilliseconds(timestamp);
            }
            else
                return DateTime.Now;
        }

        private static string ToUTF8String(object o) 
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(Convert.ToString(o)));
        }

        public static WarningResult GetWarnings()
        {
            IList<Warning> warningList = new List<Warning>();

            JObject apiResponse = ApiClient.GetResponse();
            JToken warnings = apiResponse["warnings"];

            if (warnings != null)
            {
                Dictionary<int, object> areaWarnings = JsonConvert.DeserializeObject<Dictionary<int, object>>(warnings.ToString());
                foreach (var areaWarning in areaWarnings)
                {
                    var responseItems = JArray.Parse(areaWarning.Value.ToString());
                    foreach (var item in responseItems)
                    {
                        Warning warning = new Warning()
                        {
                            AreaId = areaWarning.Key,
                            Description = ToUTF8String(item["description"]),
                            Event = ToUTF8String(item["event"]),
                            Headline = ToUTF8String(item["headline"]),
                            Instruction = ToUTF8String(item["instruction"]),
                            RegionName = ToUTF8String(item["regionName"]),
                            State = ToUTF8String(item["state"]),
                            StateShort = ToUTF8String(item["stateShort"]),
                            Type = int.Parse(item["type"].ToString()),
                            Level = int.Parse(item["level"].ToString()),
                            Start = UnixToDatetime(item["start"].ToString()),
                            End = UnixToDatetime(item["end"].ToString()),
                        };
                        warningList.Add(warning);
                    }
                }
            }

            WarningResult result = new WarningResult()
            {
                LastUpdate = UnixToDatetime(warnings["time"].ToString()),
                Warnings = warningList
            };

            return result;
        }
    }
}

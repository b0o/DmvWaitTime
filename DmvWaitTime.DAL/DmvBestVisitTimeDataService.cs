using System.Collections.Generic;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.DAL
{
    class DmvBestVisitTimeDataService : IDmvBestVisitTimeDataService
    {
        private static readonly string DmvBestVisitTimeFileLocation = 
            ConfigurationManager.AppSettings["DmvBestVisitTimeFileLocation"] ?? @"DmvBestVisitTime\";

        private const string DmvOfficeFileNameFormat = "{0}DmvBestVisitTime.txt";

        public void SaveDmvBestVisitTime(IEnumerable<DmvBestVisitTime> dmvBestVisitTimes)
        {
            string json = JsonConvert.SerializeObject(dmvBestVisitTimes);

            if (!Directory.Exists(DmvBestVisitTimeFileLocation))
            {
                Directory.CreateDirectory(DmvBestVisitTimeFileLocation);
            }

            File.WriteAllText(string.Format(DmvOfficeFileNameFormat, DmvBestVisitTimeFileLocation), json);
        }
    }
}

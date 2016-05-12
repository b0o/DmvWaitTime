using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using DmvWaitTime.DataObject;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.DAL
{
    class DmvWaitTimeFileDataService : IDmvWaitTimeDataService
    {
        private static readonly string DmvWaitTimeFileLocation = 
            ConfigurationManager.AppSettings["DmvWaitTimeFileLocation"] ?? @"DmvWaitTime\";

        private static readonly string DmvWaitTimeFileLocationFormat = DmvWaitTimeFileLocation + "{0}.txt";        

        public void SaveDmvWaitTime(CurrentDmvWaitTimes currentDmvWaiTimes)
        {
            string json = JsonConvert.SerializeObject(currentDmvWaiTimes);

            if(!Directory.Exists(DmvWaitTimeFileLocation))
            {
                Directory.CreateDirectory(DmvWaitTimeFileLocation);
            }

            File.WriteAllText(string.Format(DmvWaitTimeFileLocationFormat, currentDmvWaiTimes.CurrentDateTime.ToString("yyyyMMddHHmmss")), json);
        }

        public IEnumerable<CurrentDmvWaitTimes> LoadDmvWaitTime()
        {
            var files = Directory.GetFiles(DmvWaitTimeFileLocation);

            foreach(var file in files)
            {
                string json = File.ReadAllText(file);

                var dmvWaitTime = JsonConvert.DeserializeObject<CurrentDmvWaitTimes>(json);

                yield return dmvWaitTime;
            }
        }
    }
}

using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;
using System.IO;
using DmvWaitTime.DataObject;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.DAL
{
    class DmvOfficeFileDataService : IDmvOfficeDataService
    {
        private static readonly string DmvOfficesFileLocation = 
            ConfigurationManager.AppSettings["DmvOfficesFileLocation"] ?? @"DmvOffices\";

        private const string DmvOfficeFileNameFormat = "{0}DmvOffices.txt";

        public void SaveDmvOffices(IEnumerable<DmvOffice> currentOffices)
        {
            string json = JsonConvert.SerializeObject(currentOffices);

            if (!Directory.Exists(DmvOfficesFileLocation))
            {
                Directory.CreateDirectory(DmvOfficesFileLocation);
            }

            File.WriteAllText(string.Format(DmvOfficeFileNameFormat, DmvOfficesFileLocation), json);
        }
    }
}

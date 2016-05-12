using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using DmvWaitTime.Provider.Contracts.Builders;
using DmvWaitTime.Provider.Contracts.Providers;

namespace DmvWaitTime.Provider.Components.Providers
{
    class DmvWaitTimeProvider : IDmvWaitTimeProvider
    {
        private static readonly string CurrentWaitTimeUrl = 
            ConfigurationManager.AppSettings["CurrentWaitTimeUrl"] ?? "https://www.dmv.ca.gov/wasapp/webdata/output3.txt?_=1461961888704";

        private readonly IMyDmvWaitTimeBuilder _myDmvWaitTimeBuilder;

        public DmvWaitTimeProvider(IMyDmvWaitTimeBuilder myDmvWaitTimeBuilder)
        {
            _myDmvWaitTimeBuilder = myDmvWaitTimeBuilder;
        }

        public IEnumerable<DataObject.Local.DmvWaitTime> GetCurrentDmvWaitTimes()
        {
            WebClient client = new WebClient();

            var currentWaitData = client.DownloadData(CurrentWaitTimeUrl);

            return _myDmvWaitTimeBuilder.Build(currentWaitData);
        }
    }
}

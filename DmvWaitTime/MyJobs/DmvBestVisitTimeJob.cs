using DmvWaitTime.DAL;
using System;
using System.Collections.Generic;
using DmvWaitTime.DataObject.Local;
using DmvWaitTime.Logging;
using DmvWaitTime.Service;

namespace DmvWaitTime.MyJobs
{
    class DmvBestVisitTimeJob : IMyJob<DmvBestVisitTime>
    {
        private readonly IDmvWaitTimeDataService _dmvWaitTimeDataService;

        private readonly IDmvBestVisitTimeService _dmvBestVisitTimeService;

        private readonly IDmvBestVisitTimeDataService _dmvBestVisitTimeDataService;

        private readonly IMyLogger _logger;

        public DmvBestVisitTimeJob(
            IDmvWaitTimeDataService dmvWaitTimeDataService,
            IDmvBestVisitTimeService dmvBestVisitTimeService,
            IDmvBestVisitTimeDataService dmvBestVisitTimeDataService, 
            IMyLogger logger)
        {
            _dmvWaitTimeDataService = dmvWaitTimeDataService;

            _dmvBestVisitTimeService = dmvBestVisitTimeService;

            _dmvBestVisitTimeDataService = dmvBestVisitTimeDataService;
            _logger = logger;
        }

        public void Execute()
        {
            try
            {
                IEnumerable<CurrentDmvWaitTimes> dmvWaitTimes = _dmvWaitTimeDataService.LoadDmvWaitTime();

                var dmvBestVistTimes = _dmvBestVisitTimeService.GetDmvBestVisitTimes(dmvWaitTimes);

                _dmvBestVisitTimeDataService.SaveDmvBestVisitTime(dmvBestVistTimes);
            }
            catch (Exception err)
            {
                _logger.Log(err.Message);
            }
        }
    }
}

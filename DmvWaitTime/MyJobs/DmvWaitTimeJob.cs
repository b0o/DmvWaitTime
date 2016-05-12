using DmvWaitTime.DAL;
using DmvWaitTime.Logging;
using System;
using DmvWaitTime.DataObject.Local;
using DmvWaitTime.Provider.Contracts.Providers;

namespace DmvWaitTime.MyJobs
{
    class DmvWaitTimeJob : IMyJob<CurrentDmvWaitTimes>
    {        
        private readonly IDmvWaitTimeProvider _dmvWaitTimeProvider;

        private readonly IDmvWaitTimeDataService _dmvWaitTimeDataService;

        private readonly IMyLogger _logger;

        public DmvWaitTimeJob(IDmvWaitTimeProvider dmvWaitTimeProvider, IDmvWaitTimeDataService dmvWaitTimeDataService, IMyLogger logger)
        {
            _dmvWaitTimeProvider = dmvWaitTimeProvider;

            _dmvWaitTimeDataService = dmvWaitTimeDataService;

            _logger = logger;
        }

        public void Execute()
        {
            try
            {
                var currentDateTime = DateTime.Now;

                var currentDmvWaitTimes = _dmvWaitTimeProvider.GetCurrentDmvWaitTimes();

                _dmvWaitTimeDataService.SaveDmvWaitTime(
                    new CurrentDmvWaitTimes
                    {
                        CurrentDateTime = currentDateTime,
                        DmvWaitTimes = currentDmvWaitTimes
                    });
            }
            catch(Exception ex)
            {
                _logger.Log(ex.Message);
            }
        }
    }
}

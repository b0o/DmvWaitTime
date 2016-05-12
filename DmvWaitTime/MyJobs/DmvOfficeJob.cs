using DmvWaitTime.DAL;
using DmvWaitTime.Logging;
using System;
using DmvWaitTime.DataObject.Local;
using DmvWaitTime.Provider.Contracts.Providers;

namespace DmvWaitTime.MyJobs
{
    class DmvOfficeJob : IMyJob<DmvOffice>
    {
        private readonly IDmvOfficesProvider _dmvOfficeProvider;

        private readonly IDmvOfficeDataService _dmvOfficeDataService;

        private readonly IMyLogger _logger;

        public DmvOfficeJob(IDmvOfficesProvider dmvOfficeProvider, IDmvOfficeDataService dmvOfficeDataService, IMyLogger logger)
        {
            _dmvOfficeProvider = dmvOfficeProvider;

            _dmvOfficeDataService = dmvOfficeDataService;

            _logger = logger;
        }

        public void Execute()
        {
            try
            {
                var currentOffices = _dmvOfficeProvider.GetDmvOffices();

                _dmvOfficeDataService.SaveDmvOffices(currentOffices);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
            }
        }
    }
}

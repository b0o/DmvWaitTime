using DmvWaitTime.MyJobs;
using System;
using System.Threading.Tasks;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.MyJobSchedulers
{
    class DmvOfficeScheduler : IScheduler
    {
        private readonly IMyJob<DmvOffice> _dmvOfficeJob;

        public DmvOfficeScheduler(IMyJob<DmvOffice> dmvOfficeJob)
        {
            _dmvOfficeJob = dmvOfficeJob;
        }

        public void ScheduleJob()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    _dmvOfficeJob.Execute();
                    await Task.Delay(new TimeSpan(30, 0, 0, 0));
                }
            });
        }
    }
}

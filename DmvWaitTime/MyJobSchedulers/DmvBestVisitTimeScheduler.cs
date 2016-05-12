using DmvWaitTime.MyJobs;
using System.Threading.Tasks;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.MyJobSchedulers
{
    class DmvBestVisitTimeScheduler : IScheduler
    {
        private readonly IMyJob<DmvBestVisitTime> _dmvBestVisitJob;

        public DmvBestVisitTimeScheduler(IMyJob<DmvBestVisitTime> dmvBestVisitJob)
        {
            _dmvBestVisitJob = dmvBestVisitJob;
        }

        public void ScheduleJob()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    _dmvBestVisitJob.Execute();

                    await Task.Delay(60 * 1000);
                }
            });
        }
    }
}

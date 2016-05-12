using System.Collections.Generic;
using DmvWaitTime.DataObject.Local;
using DmvWaitTime.MyJobs;
using DmvWaitTime.MyJobSchedulers;
using SimpleInjector;

namespace DmvWaitTime.MySchedulerFactory
{
    class SchedulerFactory
    {
        public static IEnumerable<IScheduler> GetSchedulers(Container container)
        {
            var dmvWaitTimeJob = container.GetInstance<IMyJob<CurrentDmvWaitTimes>>();

            yield return new DmvWaitTimeScheduler(dmvWaitTimeJob);

            var dmvOfficeJob = container.GetInstance<IMyJob<DmvOffice>>();

            yield return new DmvOfficeScheduler(dmvOfficeJob);

            var dmvBestVistTimeJob = container.GetInstance<IMyJob<DmvBestVisitTime>>();

            yield return new DmvBestVisitTimeScheduler(dmvBestVistTimeJob);
        }
    }
}

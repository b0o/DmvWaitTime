using DmvWaitTime.MyJobs;
using System;
using System.Threading.Tasks;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.MyJobSchedulers
{
    class DmvWaitTimeScheduler : IScheduler
    {
        private readonly IMyJob<CurrentDmvWaitTimes> _dmvWaitTimeJob;

        public DmvWaitTimeScheduler(IMyJob<CurrentDmvWaitTimes> dmvWaitTimeJob)
        {
            _dmvWaitTimeJob = dmvWaitTimeJob;
        }

        public void ScheduleJob()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    if (OfficeIsOpen(DateTime.Now))
                    {
                        _dmvWaitTimeJob.Execute();
                    }
                    await Task.Delay(60 * 1000);
                }
            });
        }

        private bool OfficeIsOpen(DateTime now)
        {
            var startTime = new TimeSpan(08, 0, 0);

            var endTime = new TimeSpan(17, 0, 0);

            var startDate = DayOfWeek.Monday;

            var endDate = DayOfWeek.Friday;

            if (now.TimeOfDay >= startTime &&
                now.TimeOfDay <= endTime &&
                now.DayOfWeek >= startDate &&
                now.DayOfWeek <= endDate)
            {
                return true;
            }

            return false;
        }
    }
}

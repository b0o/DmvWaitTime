using DmvWaitTime.DataObject.Local;
using DmvWaitTime.MyJobs;
using SimpleInjector;

namespace DmvWaitTime
{
    public class AppModule
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IMyJob<CurrentDmvWaitTimes>, DmvWaitTimeJob>();

            container.Register<IMyJob<DmvOffice>, DmvOfficeJob>();

            container.Register<IMyJob<DmvBestVisitTime>, DmvBestVisitTimeJob>();
        }
    }
}

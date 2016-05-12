using SimpleInjector;

namespace DmvWaitTime.Service
{
    public class AppModule
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IDmvBestVisitTimeService, DmvBestVisitTimeService>();
        }
    }
}

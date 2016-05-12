using SimpleInjector;

namespace DmvWaitTime.DAL
{
    public class AppModule
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IDmvWaitTimeDataService, DmvWaitTimeFileDataService>();

            container.Register<IDmvBestVisitTimeDataService, DmvBestVisitTimeDataService>();

            container.Register<IDmvOfficeDataService, DmvOfficeFileDataService>();
        }
    }
}

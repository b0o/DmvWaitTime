using SimpleInjector;

namespace DmvWaitTime.Logging
{
    public class AppModule
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IMyLogger, MyLogger>();
        }
    }
}

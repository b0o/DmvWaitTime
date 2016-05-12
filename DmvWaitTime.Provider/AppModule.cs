using DmvWaitTime.Provider.Components.Builders;
using DmvWaitTime.Provider.Components.Providers;
using DmvWaitTime.Provider.Contracts.Builders;
using DmvWaitTime.Provider.Contracts.Providers;
using SimpleInjector;

namespace DmvWaitTime.Provider
{
    public class AppModule
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IDmvOfficesProvider, DmvOfficesProvider>();

            container.Register<IDmvWaitTimeProvider, DmvWaitTimeProvider>();

            container.Register<IMyDmvOfficeBuilder, MyDmvOfficeBuilder>();

            container.Register<IMyDmvWaitTimeBuilder, MyDmvWaitTimeBuilder>();
        }
    }
}

using Topshelf;

namespace DmvWaitTime
{
    class Program
    {        
        static void Main(string[] args)
        {
            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<MyDmvService>(serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsing(() => new MyDmvService());

                    serviceConfigurator.WhenStarted(myService => myService.Start());

                    serviceConfigurator.WhenStopped(myService => myService.Stop());
                });

                hostConfigurator.RunAsLocalSystem();

                hostConfigurator.SetDisplayName("MyDmvService");
                hostConfigurator.SetDescription("Runs on sheduler to grab dmv information for analysis");
                hostConfigurator.SetServiceName("MyDmvService");
            });
        }
    }
}

using DmvWaitTime.Logging;
using DmvWaitTime.MySchedulerFactory;
using SimpleInjector;

namespace DmvWaitTime
{
    public class MyDmvService
    {
        private readonly Container _container = new Container();

        private readonly IMyLogger _logger;

        public MyDmvService()
        {
            AppModule.RegisterServices(_container);

            _logger = _container.GetInstance<IMyLogger>();
        }

        public void Start()
        {
            _logger.Log("Starting DmvWaitTime Service");

            foreach(var service in SchedulerFactory.GetSchedulers(_container))
            {
                service.ScheduleJob();
            }
        }

        public void Stop()
        {
            _logger.Log("Stopping DmvWaitTime Service");
            _container.Dispose();
        }
    }
}

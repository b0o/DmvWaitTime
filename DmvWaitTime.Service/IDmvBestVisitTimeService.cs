using System.Collections.Generic;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.Service
{
    public interface IDmvBestVisitTimeService
    {
        IEnumerable<DmvBestVisitTime> GetDmvBestVisitTimes(IEnumerable<CurrentDmvWaitTimes> dmvWaitTimes);
    }
}

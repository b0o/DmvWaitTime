using System.Collections.Generic;
using DmvWaitTime.DataObject;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.DAL
{
    public interface IDmvBestVisitTimeDataService
    {
        void SaveDmvBestVisitTime(IEnumerable<DmvBestVisitTime> dmvBestVisitTimes);
    }
}

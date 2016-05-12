using System.Collections.Generic;
using DmvWaitTime.DataObject;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.DAL
{
    public interface IDmvWaitTimeDataService
    {
        void SaveDmvWaitTime(CurrentDmvWaitTimes currentDmvWaitTimes);

        IEnumerable<CurrentDmvWaitTimes> LoadDmvWaitTime();
    }
}

using System.Collections.Generic;
using DmvWaitTime.DataObject;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.DAL
{
    public interface IDmvOfficeDataService
    {
        void SaveDmvOffices(IEnumerable<DmvOffice> currentOffices);
    }
}

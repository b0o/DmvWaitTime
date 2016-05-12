using System.Collections.Generic;
using DmvWaitTime.DataObject.Local;
using DmvWaitTime.DmvObjects;

namespace DmvWaitTime.Provider.Contracts.Builders
{
    public interface IMyDmvOfficeBuilder
    {
        IEnumerable<DmvOffice> GetMyDmvOffices(DmvOffices dmvOffices);
    }
}

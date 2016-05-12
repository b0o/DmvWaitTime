using System.Collections.Generic;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.Provider.Contracts.Providers
{
    public interface IDmvOfficesProvider
    {
        IEnumerable<DmvOffice> GetDmvOffices();
    }
}

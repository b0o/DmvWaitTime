using System.Collections.Generic;

namespace DmvWaitTime.Provider.Contracts.Providers
{
    public interface IDmvWaitTimeProvider
    {
        IEnumerable<DataObject.Local.DmvWaitTime> GetCurrentDmvWaitTimes();
    }
}

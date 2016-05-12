using System.Collections.Generic;

namespace DmvWaitTime.Provider.Contracts.Builders
{
    interface IMyDmvWaitTimeBuilder
    {
        IEnumerable<DataObject.Local.DmvWaitTime> Build(byte[] data);
    }
}

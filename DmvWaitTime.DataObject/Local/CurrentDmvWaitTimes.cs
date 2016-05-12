using System;
using System.Collections.Generic;

namespace DmvWaitTime.DataObject.Local
{
    public class CurrentDmvWaitTimes
    {
        public DateTime CurrentDateTime { get; set; }

        public IEnumerable<DmvWaitTime> DmvWaitTimes { get; set; }
    }
}

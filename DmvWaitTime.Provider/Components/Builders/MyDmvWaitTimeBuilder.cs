using System;
using System.Collections.Generic;
using DmvWaitTime.Provider.Contracts.Builders;

namespace DmvWaitTime.Provider.Components.Builders
{
    class MyDmvWaitTimeBuilder : IMyDmvWaitTimeBuilder
    {
        public IEnumerable<DataObject.Local.DmvWaitTime> Build(byte[] data)
        {
            var str = System.Text.Encoding.Default.GetString(data).Replace("ï»¿", "");

            foreach (string row in str.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var columns = row.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                int branchId;
                if (int.TryParse(columns[0], out branchId))
                {
                    yield return new DataObject.Local.DmvWaitTime
                    {
                        BranchId = branchId,
                        AppointmentWaitTimeString = columns[1],
                        NonAppointmentWaitTimeString = columns[2]
                    };
                }
            }
        }
    }
}

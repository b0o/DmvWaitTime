using System.Collections.Generic;
using DmvWaitTime.DataObject.Local;
using DmvWaitTime.DmvObjects;
using DmvWaitTime.Provider.Contracts.Builders;

namespace DmvWaitTime.Provider.Components.Builders
{
    class MyDmvOfficeBuilder : IMyDmvOfficeBuilder
    {
        public IEnumerable<DmvOffice> GetMyDmvOffices(DmvOffices dmvOffices)
        {
            foreach(var dmvOffice in dmvOffices.foims_offices.offices)
            {
                yield return BuildMyDmvOffice(dmvOffice);
            }
        }

        private DmvOffice BuildMyDmvOffice(Office dmvOffice)
        {
            return new DmvOffice
            {
                Number = dmvOffice.number,
                Name = dmvOffice.name,
                Address = dmvOffice.address,
                Phone = dmvOffice.phone,
                OfficeHours = dmvOffice.officeHours,
                Region = dmvOffice.region,
                Latitude = dmvOffice.latitude,
                Longitude = dmvOffice.longitude
            };
        }
    }
}

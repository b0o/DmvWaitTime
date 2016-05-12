using System.Collections.Generic;
using DmvWaitTime.DataObject.Local;
using DmvWaitTime.DmvObjects;
using DmvWaitTime.Provider.Contracts.Builders;
using DmvWaitTime.Provider.Contracts.Providers;
using Newtonsoft.Json;
using RestSharp;

namespace DmvWaitTime.Provider.Components.Providers
{
    class DmvOfficesProvider : IDmvOfficesProvider
    {
        private const string DmvOfficeUrl = "http://apps.dmv.ca.gov/web/data/foims_offices_min.json?_=1461525172200";

        private readonly IMyDmvOfficeBuilder _myDmvOfficeBuilder;

        public DmvOfficesProvider(IMyDmvOfficeBuilder myDmvOfficeBuilder)
        {
            _myDmvOfficeBuilder = myDmvOfficeBuilder;
        }

        public IEnumerable<DmvOffice> GetDmvOffices()
        {
            RestClient restClient = new RestClient(DmvOfficeUrl);

            RestRequest restRequest = new RestRequest(Method.GET);

            string responseJson = restClient.Execute(restRequest).Content;

            var dmvOffices = JsonConvert.DeserializeObject<DmvOffices>(responseJson);

            return _myDmvOfficeBuilder.GetMyDmvOffices(dmvOffices);
        }
    }
}

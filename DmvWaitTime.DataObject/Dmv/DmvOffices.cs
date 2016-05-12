using System.Collections.Generic;

namespace DmvWaitTime.DmvObjects
{
    public class DmvOffices
    {
        public FoimsOffices foims_offices { get; set; }
    }

    public class Disclaimer
    {
        public int id { get; set; }
        public string section { get; set; }
        public int order { get; set; }
        public string english { get; set; }
        public string spanish { get; set; }
    }

    public class Office
    {
        public string name { get; set; }
        public int number { get; set; }
        public string region { get; set; }
        public string officeHours { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int nrby1 { get; set; }
        public int nrby2 { get; set; }
        public int nrby3 { get; set; }
        public int nrby4 { get; set; }
        public int nrby5 { get; set; }
        public bool cDLID { get; set; }
        public bool cDLPC { get; set; }
        public bool cVR { get; set; }
        public bool cCDL { get; set; }
        public bool cMDT { get; set; }
        public bool cQueue { get; set; }
        public bool cSST { get; set; }
        public List<Disclaimer> disclaimers { get; set; }
    }

    public class FoimsOffices
    {
        public string createTime { get; set; }
        public List<Office> offices { get; set; }
    }
}

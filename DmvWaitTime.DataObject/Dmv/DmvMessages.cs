using System.Collections.Generic;

namespace DmvWaitTime.DataObject.Dmv
{
    public class DmvMessages
    {
        public FoimsMessages foims_messages { get; set; }
    }

    public class Message
    {
        public int id { get; set; }
        public int officeNumber { get; set; }
        public string type { get; set; }
        public string activeDate { get; set; }
        public string closingDate { get; set; }
        public string expireDate { get; set; }
        public string english { get; set; }
        public string spanish { get; set; }
    }

    public class FoimsMessages
    {
        public string createTime { get; set; }
        public List<Message> messages { get; set; }
    }
}

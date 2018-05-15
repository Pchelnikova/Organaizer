using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DataContracts
{
    [DataContract]
    public class Profit_WCF
    {
        [DataMember]
        public DateTime Date_ { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
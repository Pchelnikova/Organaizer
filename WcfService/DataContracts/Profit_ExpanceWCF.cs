using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DataContracts
{
    [DataContract]
    public class Profit_ExpanceWCF
    {
        [DataMember]
        public DateTime Date_ { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Profit_Expanc_Type { get; set; }
    }
}
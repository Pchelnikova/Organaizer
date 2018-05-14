using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DataContracts
{
    [DataContract]
    public class Diary_WCF
    {
        [DataMember]
        public DateTime Date_ { get; set; }
        [DataMember]
        public string Text { get; set; }       
    }
}
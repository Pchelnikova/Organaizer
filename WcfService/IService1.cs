using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.DataContracts;

namespace WcfOrganizer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Diary_WCF> Show_All_Notes(string login);
        [OperationContract]
        void Add_Note(string note, string login);
        [OperationContract]
        void Delete_Note(string note);
       

        //Budget
        [OperationContract]
        List<Profit_ExpanceWCF> Show_All_Profits(string login);
        [OperationContract]
        List<Profit_ExpanceWCF> Show_All_Expance(string login);
        [OperationContract]
        List<string> GetProfitsTypes();
        [OperationContract]
        List<string> GetExpanceTypes();
        [OperationContract]
        void Save_New_Expance(Profit_ExpanceWCF new_expance, string login);
        [OperationContract]
        void Save_New_Profit(Profit_ExpanceWCF new_profit, string login);


        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}

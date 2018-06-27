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
        List<Diary_WCF> Get_All_Notes(string login);
        [OperationContract]
        void Add_Note(string note, string login);
        [OperationContract]
        void Delete_Note(string note);
       

        //Budget
        [OperationContract]
        List<Profit_ExpanceWCF> Get_All_Profits(string login);
        [OperationContract]
        List<Profit_ExpanceWCF> Get_All_Expance(string login);
        [OperationContract]
        List<Profit_ExpanceWCF> Get_All_Plans(string login);
        [OperationContract]
        List<string> GetProfitsTypes();
        [OperationContract]
        List<string> GetExpanceTypes();
        [OperationContract]
        void Save_New_Expance(Profit_ExpanceWCF new_expance, string Type, string login);
        [OperationContract]
        void Save_New_Profit(Profit_ExpanceWCF new_profit, string Type, string login);
        [OperationContract]
        void Save_New_Plan(Profit_ExpanceWCF new_expance, string Type, string login);
        [OperationContract]
        void Delete_Profit(Profit_ExpanceWCF profit_ExpanceWCF, string login);
        [OperationContract]
        void Delete_Expence(Profit_ExpanceWCF profit_ExpanceWCF, string login);
        [OperationContract]
        void Delete_Plan(Profit_ExpanceWCF profit_ExpanceWCF, string login);
        [OperationContract]
        decimal Get_Total_Profits();
        [OperationContract]
        decimal Get_Total_Expences();
        [OperationContract]
        decimal Get_Total_Plans();
        [OperationContract]
        decimal Get_Balance();
        [OperationContract]
        bool Authorization(string login, string parol);
        [OperationContract]
        bool Create_New_User(string login, string password);
    }  
}

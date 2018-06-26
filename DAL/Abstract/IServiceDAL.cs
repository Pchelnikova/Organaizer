using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IServiceDAL
    {
        List<Diary> Show_All_Notes(string login);
        void Add_Note(string note, string login);
        void Delete_Note(string note);
        List<Profit> Get_All_Profits(string login);
        void Save_New_Profit(DateTime date, Decimal sum, string description, string Type, string login);
        void Delete_Profit(Profit profit);
        List<Expence> Get_All_Expance(string login);
        void Save_New_Expance(DateTime date, Decimal sum, string description, string Type, string login);
        void Delete_Expence(Expence expence, string login);
        List<Plan> Get_All_Plan(string login);
        void Save_New_Plan(DateTime date, Decimal sum, string description, string Type, string login);
        void Delete_Plan(Plan plan, string login);
        decimal Get_Total_Profits();
        decimal Get_Total_Expences();
        decimal Get_Total_Plans();
        decimal Get_Balance();
        bool Authorization(string login, string parol);
        bool Create_New_User(string login, string password);
        List<string> GetExpanceTypes();
        List<string> GetProfitsTypes();
    }
}

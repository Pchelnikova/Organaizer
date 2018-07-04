using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IServiceDAL
    {
        List<Diary> Get_All_Notes(string login);
        void Add_Note(string note, string login);
        void Delete_Note(string note);
        List<Profit> Get_All_Profits(string login);
        void Save_New_Profit(DateTime date, Decimal sum, string description, string Type, string login);
        void Delete_Profit(Profit profit);
        List<Expense> Get_All_Expance(string login);
        void Save_New_Expance(DateTime date, Decimal sum, string description, string Type, string login);
        void Delete_Expence(Expense expence);
        List<Plan> Get_All_Plan(string login);
        void Save_New_Plan(DateTime date, Decimal sum, string description, string Type, string login);
        void Delete_Plan(Plan plan);
        decimal Get_Total_Profits();
        decimal Get_Total_Expences();
        decimal Get_Total_Plans();
        decimal Get_Balance();
        bool Authorization(string login, string parol);
        bool Create_New_User(string login, string password);        
        List<string> GetExpanceTypes();
        List<string> GetProfitsTypes();
        void DeleteUser(string login);
        void ChangeUser_Login(string login, string newLogin);
        void ChangeUser_Password(string login, string newPassword);
        void ChangeUser_Status(string login, string newStatus);
        List<Diary> Diary_ByDate(string login, DateTime date1, DateTime date2);
        List<Wish> Get_All_Wishes(string login);
        void Save_New_Wish(DateTime date, Decimal sum, string description, string Type, string login);
        List<string> GetWishTypes();
        List<string> Get_Name_byType_forChart_Profits(string login);
        List<decimal> Get_Sum_byType_forChart_Profits(string login, string profit);
        List<string> Get_Name_byType_forChart_Expense(string login);
        List<decimal> Get_Sum_byType_forChart_Expense(string login, string expense);
        void Delete_Wish(Wish wish);

    }
}

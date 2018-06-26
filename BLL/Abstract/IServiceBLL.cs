using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface InterfaceBLL
    {
       List<Diary_BLL> Show_All_Notes(string login);
        void Add_Note(string note, string login);
        void Delete_Note(string note);
        List<Profit_ExpanceBLL> Get_All_Profits(string login);
        List<Profit_ExpanceBLL> Get_All_Expance(string login);
        List<Profit_ExpanceBLL> Get_All_Plans(string login);
        void Save_New_Profit(Profit_ExpanceBLL new_profit, string Type, string login);
        void Save_New_Expence(Profit_ExpanceBLL new_expance, string Type, string login);
        void Save_New_Plan(Profit_ExpanceBLL new_plan, string Type, string login);
        void Delete_Profit(Profit_ExpanceBLL profit_ExpanceBLL, string login);
        void Delete_Plan(Profit_ExpanceBLL plan_ExpanceBLL, string login);
        void Delete_Expence(Profit_ExpanceBLL profit_ExpanceBLL, string login);
        decimal Get_Total_Profits();
        decimal Get_Total_Expences();
        decimal Get_Total_Plans();
        decimal Get_Balance();
        bool Authorization(string login, string parol);
        bool Create_New_User(string login, string password);
        List<string> GetProfitsTypes();
        List<string> GetExpanceTypes();
    }
}

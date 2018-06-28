using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace BLL
{
    public class DataBLL : IServiceBLL
    {
        private readonly DataDAL _dal;

        public DataBLL (DataDAL dal)
        {
            _dal = dal;
        }

        //Diary CRUD
        #region
        public List<Diary_BLL> Show_All_Notes (string login)
        {
            var diary_list = _dal.Show_All_Notes(login);
            List<Diary_BLL> diaries = new List<Diary_BLL>();
            foreach (Diary item in diary_list)
                diaries.Add(new Diary_BLL() { Date_ = item.Date, Text = item.Text });
           
            return diaries;
        }
        public void Add_Note(string note, string login)
        {
            _dal.Add_Note(note, login);
        }
        public void Delete_Note (string note)
        {
            _dal.Delete_Note(note);
        }
        #endregion

        //Budget CRUD
        #region
        public List<Profit_ExpanceBLL> Get_All_Profits(string login)
        {
            return ConverterBLL.Profit_to_BLL_List(_dal.Get_All_Profits(login));
        }
        public List<Profit_ExpanceBLL> Get_All_Expance(string login)
        {
            return ConverterBLL.Expence_to_BLL_List(_dal.Get_All_Expance(login));            
        }
        public List<Profit_ExpanceBLL> Get_All_Plans(string login)
        {
            return ConverterBLL.Plans_to_BLL_List(_dal.Get_All_Plan(login));
        }


        public void Save_New_Profit(Profit_ExpanceBLL new_profit, string Type, string login)
        {
            _dal.Save_New_Profit(new_profit.Date_, new_profit.Sum, new_profit.Description, Type, login);
        }
        public void Save_New_Expence(Profit_ExpanceBLL new_expance, string Type, string login)
        {
            _dal.Save_New_Expance(new_expance.Date_, new_expance.Sum, new_expance.Description, Type, login);
        }
        public void Save_New_Plan(Profit_ExpanceBLL new_plan, string Type, string login)
        {
            _dal.Save_New_Plan(new_plan.Date_, new_plan.Sum, new_plan.Description, Type, login);
        }


        public void Delete_Profit(Profit_ExpanceBLL profit_ExpanceBLL, string login)
        {            
            _dal.Delete_Profit(ConverterBLL.BLL_to_Profit(profit_ExpanceBLL, login));
        }
        public void Delete_Plan(Profit_ExpanceBLL plan_ExpanceBLL, string login)
        {
            _dal.Delete_Plan(ConverterBLL.BLL_to_Plan(plan_ExpanceBLL), login);
        }
       
       public void Delete_Expence (Profit_ExpanceBLL profit_ExpanceBLL, string login)
        {
            _dal.Delete_Expence(ConverterBLL.BLL_to_Expence(profit_ExpanceBLL), login);
        }
        #endregion

        //Get Total Sum and Balance
        #region
        public decimal Get_Total_Profits()
        {
            return _dal.Get_Total_Profits();
        }
        public decimal Get_Total_Expences()
        {
            return _dal.Get_Total_Expences();
        }
        public decimal Get_Total_Plans()
        {
            return _dal.Get_Total_Plans();
        }
        public decimal Get_Balance()
        {
            return _dal.Get_Balance();
        }
        #endregion

        //Authorization
        public bool Authorization(string login, string parol)
        {
            return _dal.Authorization(login, parol);
        }
        public bool Create_New_User(string login, string password)
        {
            return _dal.Create_New_User(login, password);
        }

        public List<string> GetProfitsTypes ()
        {
            return _dal.GetProfitsTypes();
        }
        public List<string> GetExpanceTypes()
        {
            return _dal.GetExpanceTypes();
        }
        public void ChangesUserInfo(string login, string newLogin, string newPassword, string status)
        {
            _dal.ChangesUserInfo(login,newLogin,newPassword,status);
        }
    }
}

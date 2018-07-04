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
        public DataBLL(DataDAL dal)
        {
            _dal = dal;
        }
        //Wish CRUD
        #region
        public List<Profit_ExpanceBLL> Get_All_Wishes(string login)
        {
            return ConverterBLL.Wish_to_BLL_List(_dal.Get_All_Wishes(login));
        }
        public void Save_New_Wish(Profit_ExpanceBLL new_wish, string Type, string login)
        {
            _dal.Save_New_Wish(new_wish.Date_, new_wish.Sum, new_wish.Description, Type, login);
        }
        public List<string> GetWishTypes()
        {
            return _dal.GetWishTypes();
        }
        #endregion

        //Diary CRUD
        #region
        public List<Diary_BLL> Show_All_Notes(string login)
        {
            var diary_list = _dal.Get_All_Notes(login);
            List<Diary_BLL> diaries = new List<Diary_BLL>();
            foreach (Diary item in diary_list)
                diaries.Add(new Diary_BLL() { Date_ = item.Date, Text = item.Text });
            return diaries;
        }
        public void Add_Note(string note, string login)
        {
            _dal.Add_Note(note, login);
        }
        public void Delete_Note(string note)
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

        public void Delete_Expence(Profit_ExpanceBLL profit_ExpanceBLL, string login)
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
        public List<string> GetProfitsTypes()
        {
            return _dal.GetProfitsTypes();
        }
        public List<string> GetExpanceTypes()
        {
            return _dal.GetExpanceTypes();
        }
        public void DeleteUser(string login)
        {
            _dal.DeleteUser(login);
        }
        public void ChangeUser_Login(string login, string newLogin)
        {
            _dal.ChangeUser_Login(login, newLogin);
        }
        public void ChangeUser_Password(string login, string newPassword)
        {
            _dal.ChangeUser_Password(login, newPassword);
        }
        public void ChangeUser_Status(string login, string newStatus)
        {
            _dal.ChangeUser_Status(login, newStatus);
        }
        public List<Diary_BLL> Diary_ByDate(string login, DateTime date1, DateTime date2)
        {
            var diary_list = _dal.Diary_ByDate(login, date1, date2);
            var diaries = new List<Diary_BLL>();
            foreach (var item in diary_list)
            {
                diaries.Add(new Diary_BLL()
                {
                    Date_ = item.Date,
                    Text = item.Text
                });
            }
            return diaries;
        }
        public Dictionary<string, decimal> Get_Sum_byType_forChart_Profits()
        {
            return _dal.Get_Sum_byType_forChart_Profits();
        }
    }
}

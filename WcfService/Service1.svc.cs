using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL;
using WcfService.DataContracts;
using WcfService.Converters;


namespace WcfOrganizer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly DataBLL _bll;

        public Service1(DataBLL bll)
        {
            _bll = bll;
        }
        
        #region Diary
        public List<Diary_WCF> Get_All_Notes(string login)
        {
            var diary_list = _bll.Show_All_Notes(login);
            var diaries = new List<Diary_WCF>();
            foreach (BLL.Diary_BLL item in diary_list)
            {
                diaries.Add(new Diary_WCF() { Date_ = item.Date_, Text = item.Text });
            }
            return diaries;
        }
        public void Add_Note(string note, string login)
        {
            _bll.Add_Note(note, login);
        }
        public void Delete_Note(string note)
        {
            if (note != null)
                _bll.Delete_Note(note);
        }
        public List<Diary_WCF> Diary_ByDate(string login, DateTime date1, DateTime date2)
        {
            var diary_list = _bll.Diary_ByDate(login, date1, date2);
            var diaries = new List<Diary_WCF>();
            foreach (var item in diary_list)
            {
                diaries.Add(new Diary_WCF()
                {
                    Date_ = item.Date_,
                    Text = item.Text
                });
            }
            return diaries;
        }
        #endregion

        #region Profit
        public List<Profit_ExpanceWCF> Get_All_Profits(string login)
        {
            return Converter.BLL_to_WCF_List(_bll.Get_All_Profits(login));
        }
        public List<Profit_ExpanceWCF> Get_All_Profits_forOwner()
        {
            return Converter.BLL_to_WCF_List(_bll.Get_All_Profits());
        }
        public void Save_New_Profit(Profit_ExpanceWCF new_profit, string Type, string login)
        {
            _bll.Save_New_Profit(Converter.WCF_to_BLL(new_profit), Type, login);
        }
        public void Delete_Profit(Profit_ExpanceWCF profit_ExpanceWCF, string login)
        {
            _bll.Delete_Profit(Converter.WCF_to_BLL(profit_ExpanceWCF), login);
        }
        #endregion

        #region Expance
        public void Save_New_Expance(Profit_ExpanceWCF new_expance, string Type, string login)
        {
            _bll.Save_New_Expence(Converter.WCF_to_BLL(new_expance), Type, login);
        }
        public List<Profit_ExpanceWCF> Get_All_Expance(string login)
        {
            return Converter.BLL_to_WCF_List(_bll.Get_All_Expance(login));
        }
        public void Delete_Expence(Profit_ExpanceWCF profit_ExpanceWCF, string login)
        {
            _bll.Delete_Expence(Converter.WCF_to_BLL(profit_ExpanceWCF), login);
        }
        #endregion

        #region Wish
        public List<Profit_ExpanceWCF> Get_All_Wishes(string login)
        {
            return Converter.BLL_to_WCF_List(_bll.Get_All_Wishes(login));
        }
        public void Save_New_Wish(Profit_ExpanceWCF new_wish, string Type, string login)
        {
            _bll.Save_New_Wish(Converter.WCF_to_BLL(new_wish), Type, login);
        }
        #endregion

        #region Plans
        public void Save_New_Plan(Profit_ExpanceWCF new_plan, string Type, string login)
        {
            _bll.Save_New_Plan(Converter.WCF_to_BLL(new_plan), Type, login);
        }
        public List<Profit_ExpanceWCF> Get_All_Plans(string login)
        {
            return Converter.BLL_to_WCF_List(_bll.Get_All_Plans(login));
        }
        public void Delete_Plan(Profit_ExpanceWCF profit_ExpanceWCF, string login)
        {
            _bll.Delete_Plan(Converter.WCF_to_BLL(profit_ExpanceWCF), login);
        }
        #endregion

        #region Get Total Summ And Balance
        public decimal Get_Total_Profits()
        {
            return _bll.Get_Total_Profits();
        }
        public decimal Get_Total_Expences()
        {
            return _bll.Get_Total_Expences();
        }
        public decimal Get_Total_Plans()
        {
            return _bll.Get_Total_Plans();
        }
        public decimal Get_Balance()
        {
            return _bll.Get_Balance();
        }
        #endregion

        #region Authorization and User
        public bool Authorization(string login, string parol)
        {
            return _bll.Authorization(login, parol);
        }
        public bool Create_New_User(string login, string password)
        {
            return _bll.Create_New_User(login, password);
        }
        public void DeleteUser(string login)
        {
            _bll.DeleteUser(login);
        }
        public void ChangeUser_Login(string login, string newLogin)
        {
            _bll.ChangeUser_Login(login, newLogin);
        }
        public void ChangeUser_Password(string login, string newPassword)
        {
            _bll.ChangeUser_Password(login, newPassword);
        }
        public void ChangeUser_Status(string login, string newStatus)
        {
            _bll.ChangeUser_Status(login, newStatus);
        }
        #endregion

        #region Types
        public List<string> GetProfitsTypes()
        {
            return _bll.GetProfitsTypes();
        }
        public List<string> GetExpanceTypes()
        {
            return _bll.GetExpanceTypes();
        }
        public List<string> GetWishTypes()
        {
            return _bll.GetWishTypes();
        }
        /// <summary>
        /// Check of rang of User
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Return "true", if rang of user is high ("Senior")</returns>
        public bool GetTypeUser(string login)
        {
            return _bll.GetTypeUser( login);
        }
        public List<string> GetAllJuniors()
        {
            return _bll.GetAllJuniors();
        }
        public List<string> GetAllRangs()
        {
            return _bll.GetAllRangs();
        }

        #endregion

        #region Charts
        public List<string> Get_Name_byType_forChart_Profits(string login)
        {
            return _bll.Get_Name_byType_forChart_Profits(login);
        }
        public List<decimal> Get_Sum_byType_forChart_Profits(string login, string profit)
        {
            return _bll.Get_Sum_byType_forChart_Profits(login, profit);
        }
        public List<string> Get_Name_byType_forChart_Expense(string login)
        {
            return _bll.Get_Name_byType_forChart_Expense(login);
        }
        public List<decimal> Get_Sum_byType_forChart_Expense(string login, string expense)
        {
            return _bll.Get_Sum_byType_forChart_Expense(login, expense);
        }
        #endregion
    }
}

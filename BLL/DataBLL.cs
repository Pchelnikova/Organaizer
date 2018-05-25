using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Converters;

namespace BLL
{
    public class DataBLL
    {
        private readonly DataDAL _dal = new DataDAL();        

        public List<Diary_BLL> Show_All_Notes (string login)
        {
            var diary_list = _dal.Show_All_Notes(login);
            List<Diary_BLL> diaries = new List<Diary_BLL>();
            foreach (DAL.Model_Classes.Diary item in diary_list)
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
        //Budget CRUD
        public List<Profit_ExpanceBLL> Get_All_Profits(string login)
        {
            return Converters.Converter.Profit_to_BLL_List(_dal.Get_All_Profits(login));
        }
        public List<Profit_ExpanceBLL> Get_All_Expance(string login)
        {
            return Converters.Converter.Expence_to_BLL_List(_dal.Get_All_Expance(login));            
        }
        public List<Profit_ExpanceBLL> Get_All_Plans(string login)
        {
            return Converters.Converter.Plans_to_BLL_List(_dal.Get_All_Plan(login));
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
            _dal.Delete_Profit(Converter.BLL_to_Profit(profit_ExpanceBLL, login));
        }
        public void Delete_Plan(Profit_ExpanceBLL plan_ExpanceBLL, string login)
        {
            _dal.Delete_Plan(Converter.BLL_to_Plan(plan_ExpanceBLL), login);
        }
       
       public void Delete_Expence (Profit_ExpanceBLL profit_ExpanceBLL, string login)
        {
            _dal.Delete_Expence(Converter.BLL_to_Expence(profit_ExpanceBLL), login);
        }    
        

        public List<string> GetProfitsTypes ()
        {
            return _dal.GetProfitsTypes();
        }
        public List<string> GetExpanceTypes()
        {
            return _dal.GetExpanceTypes();
        }
    }
}

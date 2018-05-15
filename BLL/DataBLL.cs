using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

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
        public List<Profit_BLL> Show_All_Profits(string login)
        {

            var profit_list = _dal.Show_All_Profits(login);
            List<Profit_BLL> profits = new List<Profit_BLL>();
            foreach (DAL.Model_Classes.Profit item in profit_list)
                profits.Add(new Profit_BLL() { Date_ = item.Date_, Sum =item.Sum, Description = item.Description });
            return profits;

        }

        public List<string> GetProfitsTypes ()
        {
            return _dal.GetProfitsTypes();
        }
    }
}

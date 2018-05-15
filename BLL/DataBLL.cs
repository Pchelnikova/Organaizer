﻿using System;
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
        public List<Profit_ExpanceBLL> Show_All_Profits(string login)
        {

            var profit_list = _dal.Show_All_Profits(login);
            List<Profit_ExpanceBLL> profits = new List<Profit_ExpanceBLL>();
            foreach (DAL.Model_Classes.Profit item in profit_list)
                profits.Add(new Profit_ExpanceBLL() { Date_ = item.Date_, Sum =item.Sum, Description = item.Description });
            return profits;

        }
        public List<Profit_ExpanceBLL> Show_All_Expance(string login)
        {

            var expance_list = _dal.Show_All_Expance(login);
            List<Profit_ExpanceBLL> expence = new List<Profit_ExpanceBLL>();
            foreach (DAL.Model_Classes.Expance item in expance_list)
                expence.Add(new Profit_ExpanceBLL() { Date_ = item.Date_, Sum = item.Sum, Description = item.Description });
            return expence;
        }

        public void Save_New_Profit(Profit_ExpanceBLL new_profit, string login)
        {
            DAL.Model_Classes.Profit profit = new DAL.Model_Classes.Profit()
            {
                Date_ = new_profit.Date_,
                Sum = new_profit.Sum,
                Description = new_profit.Description,
               
            };
            _dal.Save_New_Profit(profit, new_profit.Profit_Expance_Type, login);
        }

        public void Save_New_Expance(Profit_ExpanceBLL new_expance, string login)
        {
            DAL.Model_Classes.Expance expance = new DAL.Model_Classes.Expance()
            {
                Date_ = new_expance.Date_,
                Sum = new_expance.Sum,
                Description = new_expance.Description
            };
            _dal.Save_New_Expance(expance, new_expance.Profit_Expance_Type, login);
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

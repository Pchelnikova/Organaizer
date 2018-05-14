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
                diaries.Add(new Diary_BLL() { Date_ = item.Date_, Text = item.Text });
           
            return diaries;
        }
    }
}
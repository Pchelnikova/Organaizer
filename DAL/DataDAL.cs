using DAL.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DataDAL
    {
        private readonly Model _ctx = new Model();
        //methods 
        public List<Diary> Show_All_Notes (string login)
        {
            var diaries = _ctx.Diaries.Where(note => note.User.Login == login).ToList();           
            return diaries;
        }

        public void Add_Note(string note, string login)
        {
            var diaries = _ctx.Diaries;//.Where(d => d.User.Login == login).ToList();
            var user = _ctx.Users.FirstOrDefault(u => u.Login == login);


            DAL.Model_Classes.Diary new_note = new DAL.Model_Classes.Diary()
            {
                Date = System.DateTime.Now,
                Text = note,
                User = user
            };
                _ctx.Diaries.Add(new_note);
                _ctx.SaveChanges();            
        }
        public void Delete_Note (string note)
        {
            var diary_note = _ctx.Diaries.FirstOrDefault(d => d.Text == note);
            _ctx.Diaries.Remove(diary_note);
            _ctx.SaveChanges();

        }

        //Budget CRUD

        public List<Profit> Show_All_Profits (string login)
        {
            var profits = _ctx.Profits.Where(pr => pr.User.Login == login).ToList();
            return profits;
        }

        public List<string> GetProfitsTypes ()
        {
            var profits_types = _ctx.Profit_Types.Select(pr => pr.Name.ToString()).ToList();
            return profits_types;
        }

    }
   
}

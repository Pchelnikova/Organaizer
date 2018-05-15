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

        public void Save_New_Profit(Profit new_profit, string profit_type, string login)
        {
            Profit profit = new Profit()
            {
                Date_ = new_profit.Date_,
                Sum = new_profit.Sum,
                User = _ctx.Users.FirstOrDefault(u => u.Login == login),
                Profit_Type = _ctx.Profit_Types.FirstOrDefault(p => p.Name == profit_type),
                Description = new_profit.Description
            };
            _ctx.Profits.Add(new_profit);
            _ctx.SaveChanges();
        }
        public void Save_New_Expance(Expance new_expance, string expance_type, string login)
        {
           Expance profit = new Expance()
            {
                Date_ = new_expance.Date_,
                Sum = new_expance.Sum,
                User = _ctx.Users.FirstOrDefault(u => u.Login == login),
                Expance_Type = _ctx.Expances_Types.FirstOrDefault(p => p.Name == expance_type),
                Description = new_expance.Description
            };
            _ctx.Expences.Add(new_expance);
            _ctx.SaveChanges();
        }
        public List<Expance> Show_All_Expance(string login)
        {
            var expance = _ctx.Expences.Where(pr => pr.User.Login == login).ToList();
            return expance;
        }

        public List<string> GetProfitsTypes ()
        {
            var profits_types = _ctx.Profit_Types.Select(pr => pr.Name.ToString()).ToList();
            return profits_types;
        }

        public List<string> GetExpanceTypes()
        {
            var expance_types = _ctx.Expances_Types.Select(pr => pr.Name.ToString()).ToList();
            return expance_types;
        }

    }
   
}

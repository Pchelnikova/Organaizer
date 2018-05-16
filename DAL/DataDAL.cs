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

        public void Save_New_Profit(Profit new_profit, string login)
        {
            Profit profit = new Profit()
            {
                Date_ = new_profit.Date_,
                Sum = new_profit.Sum,
                User = _ctx.Users.FirstOrDefault(u => u.Login == login),
            Profit_Type = _ctx.Profit_Types.FirstOrDefault(p => p.Name == new_profit.Profit_Type.Name)

            };
            _ctx.Profits.Add(profit);
            _ctx.SaveChanges();
        }
        public void Save_New_Expance(Expence new_expance, string login)
        {
           Expence expence = new Expence()
            {
                Date_ = new_expance.Date_,
                Sum = new_expance.Sum,
                User = _ctx.Users.FirstOrDefault(u => u.Login == login),
                Expence_Type = _ctx.Expances_Types.FirstOrDefault(p => p.Name == new_expance.Expence_Type.Name),
                Description = new_expance.Description
            };
            _ctx.Expences.Add(expence);
            _ctx.SaveChanges();
        }
        public List<Expence> Show_All_Expance(string login)
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

        public void Delete_Expence(DateTime expence_date)
        {
            var expence = _ctx.Expences.FirstOrDefault(d => d.Date_ == expence_date);
            _ctx.Expences.Remove(expence);
            _ctx.SaveChanges();
        }
        public void Delete_Profit(DateTime profit_date)
        {
            var expence = _ctx.Profits.FirstOrDefault(d => d.Date_ == profit_date);
            _ctx.Profits.Remove(expence);
            _ctx.SaveChanges();
        }



    }

}

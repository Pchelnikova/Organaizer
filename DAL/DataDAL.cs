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

        public List<Profit> Get_All_Profits (string login)
        {
            var profits = _ctx.Profits.Where(pr => pr.User.Id == (_ctx.Users.FirstOrDefault(u => u.Login == login)).Id).ToList();
            return profits;
        }
        public void Save_New_Profit(DateTime date, Decimal sum, string description, string Type, string login)
        {
            Profit profit = new Profit()
            {
                Date_ = date,
                Sum = sum,
                Description = description,
                User = _ctx.Users.FirstOrDefault(u => u.Login == login),
                Profit_Type = _ctx.Profit_Types.FirstOrDefault(p => p.Name == Type)
                
            };
            _ctx.Profits.Add(profit);
            _ctx.SaveChanges();
        }
        public void Delete_Profit(Profit profit)
        {
            var profit_for_del = _ctx.Profits.FirstOrDefault(d => (d.Date_ == profit.Date_ && d.Sum == profit.Sum && d.Description == profit.Description && d.User == _ctx.Users.FirstOrDefault(u => u.Login == profit.User.Login) && d.Profit_Type == _ctx.Profit_Types.FirstOrDefault(e => e.Name == profit.Profit_Type.Name)));
            if (profit_for_del != null)
            {
                _ctx.Profits.Remove(profit_for_del);
                _ctx.SaveChanges();
            }
        }

        //Expence CRUD
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
        public void Save_New_Expance(DateTime date, Decimal sum, string description, string Type, string login)
        {
            Expence expence = new Expence()
            {
                Date_ = date,
                Sum = sum,
                User = _ctx.Users.FirstOrDefault(u => u.Login == login),
                Expence_Type = _ctx.Expances_Types.FirstOrDefault(p => p.Name == Type),
                Description = description
            };
            _ctx.Expences.Add(expence);
            _ctx.SaveChanges();
        }
        public List<string> GetExpanceTypes()
        {
            var expance_types = _ctx.Expances_Types.Select(pr => pr.Name.ToString()).ToList();
            return expance_types;
        }
        public void Delete_Expence(Expence expence, string login)
        {
            var expence_for_del = _ctx.Expences.FirstOrDefault(d => d.Date_ == expence.Date_ && d.Sum == expence.Sum && d.Description == expence.Description && d.User == _ctx.Users.FirstOrDefault(u => u.Login == login) && d.Expence_Type == _ctx.Expances_Types.FirstOrDefault(e => e.Name == expence.Expence_Type.Name));
            _ctx.Expences.Remove(expence_for_del);
            _ctx.SaveChanges();
        }
       


    }

}

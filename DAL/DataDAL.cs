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
        public List<Expence> Get_All_Expance(string login)
        {
            var expance = _ctx.Expences.Where(pr => pr.User.Login == login).ToList();
            return expance;
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
        public void Delete_Expence(Expence expence, string login)
        {
            var expence_for_del = _ctx.Expences.FirstOrDefault(d => d.Date_ == expence.Date_ && d.Sum == expence.Sum && d.Description == expence.Description && d.User == _ctx.Users.FirstOrDefault(u => u.Login == login) && d.Expence_Type == _ctx.Expances_Types.FirstOrDefault(e => e.Name == expence.Expence_Type.Name));
            _ctx.Expences.Remove(expence_for_del);
            _ctx.SaveChanges();
        }

        //Plan CRUD
        public List<Plan> Get_All_Plan(string login)
        {
            var plans = _ctx.Plans.Where(pr => pr.User.Id == (_ctx.Users.FirstOrDefault(u => u.Login == login)).Id).ToList();
            return plans;
        }
        public void Save_New_Plan(DateTime date, Decimal sum, string description, string Type, string login)
        {
            Plan expence = new Plan()
            {
                Date_ = date,
                Sum = sum,
                User = _ctx.Users.FirstOrDefault(u => u.Login == login),
                Expance_Type = _ctx.Expances_Types.FirstOrDefault(p => p.Name == Type),
                Description = description
            };
            _ctx.Plans.Add(expence);
            _ctx.SaveChanges();
        }
        public void Delete_Plan(Plan plan, string login)
        {
            if (plan.Expance_Type == null)
                {
                plan.Expance_Type = _ctx.Expances_Types.FirstOrDefault(e => e.Name == "NONE!") ;
                }
            var plan_for_del = _ctx.Plans.FirstOrDefault(d => d.Date_ == plan.Date_ && d.Sum == plan.Sum && d.Description == plan.Description && d.User == _ctx.Users.FirstOrDefault(u => u.Login == login) && d.Expance_Type == _ctx.Expances_Types.FirstOrDefault(e => e.Name == plan.Expance_Type.Name));
            _ctx.Plans.Remove(plan_for_del);
            _ctx.SaveChanges();
        }

        //Get Total Sum and Balance
        #region
        public decimal Get_Total_Profits()
        {
            return _ctx.Profits.Sum(p => p.Sum);
        }
        public decimal Get_Total_Expences()
        {
            return  _ctx.Expences.Sum(p => p.Sum);
        }
        public decimal Get_Total_Plans()
        {
            return _ctx.Plans.Sum(p => p.Sum);
        }
        public decimal Get_Balance()
        {
            return (_ctx.Profits.Sum(p => p.Sum)) - ( _ctx.Expences.Sum(p => p.Sum));
        }
        #endregion

        //Types
        public List<string> GetExpanceTypes()
        {
            var expance_types = _ctx.Expances_Types.Select(pr => pr.Name.ToString()).ToList();
            return expance_types;
        }
        public List<string> GetProfitsTypes()
        {

            return _ctx.Profit_Types.Select(pr => pr.Name.ToString()).ToList();
        }
       
       


    }

}

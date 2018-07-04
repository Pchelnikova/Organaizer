
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Helper;
using static DAL.Helper.Comparators;

namespace DAL
{
    public class DataDAL : IServiceDAL
    {
        private readonly DbContext _ctx;
        public DataDAL(DbContext ctx)
        {
            _ctx = ctx;
        }

        //Diary CRUD
        #region
        public List<Diary> Get_All_Notes(string login)
        {
            var diaries = _ctx.Set<Diary>().Where(note => note.User.Login == login).ToList();
            return diaries;
        }

        public void Add_Note(string note, string login)
        {
            var diaries = _ctx.Set<Diary>();
            var user = _ctx.Set<User>().FirstOrDefault(u => u.Login == login);

            Diary new_note = new Diary()
            {
                Date = DateTime.Now,
                Text = note,
                User = user
            };
            _ctx.Set<Diary>().Add(new_note);
            _ctx.SaveChanges();
        }
        public void Delete_Note(string note)
        {
            var diary_note = _ctx.Set<Diary>().FirstOrDefault(d => d.Text == note);
            _ctx.Set<Diary>().Remove(diary_note);
            _ctx.SaveChanges();

        }
        #endregion

        //Profit CRUD
        #region

        public List<Profit> Get_All_Profits(string login)
        {
            var profits = _ctx.Set<Profit>().Where(pr => pr.User.Id == (_ctx.Set<User>().FirstOrDefault(u => u.Login == login)).Id).ToList();
            return profits;
        }
        public void Save_New_Profit(DateTime date, Decimal sum, string description, string Type, string login)
        {
            Profit profit = new Profit()
            {
                Date_ = date,
                Sum = sum,
                Description = description,
                User = _ctx.Set<User>().FirstOrDefault(u => u.Login == login),
                Profit_Type = _ctx.Set<Profit_Type>().FirstOrDefault(p => p.Name == Type)

            };
            _ctx.Set<Profit>().Add(profit);
            _ctx.SaveChanges();
        }
        public void Delete_Profit(Profit profit)
        {
            
            try
            {
                var result = _ctx.Set<Profit>().Single(new ProfitComparator(), profit);
                _ctx.Set<Profit>().Remove(result);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {                
            }        

        }
        #endregion

        //Expence CRUD
        #region
        public List<Expense> Get_All_Expance(string login)
        {
            var expance = _ctx.Set<Expense>().Where(pr => pr.User.Login == login).ToList();
            return expance;
        }

        public void Save_New_Expance(DateTime date, Decimal sum, string description, string Type, string login)
        {
            Expense expence = new Expense()
            {
                Date_ = date,
                Sum = sum,
                User = _ctx.Set<User>().FirstOrDefault(u => u.Login == login),
                Expence_Type = _ctx.Set<Expence_Type>().FirstOrDefault(p => p.Name == Type),
                Description = description
            };
            _ctx.Set<Expense>().Add(expence);
            _ctx.SaveChanges();
        }
        public void Delete_Expence(Expense expense)
        {
            try
            {
                var result = _ctx.Set<Expense>().Single(new ExpenseComparator(), expense);
                _ctx.Set<Expense>().Remove(result);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        //Plan CRUD
        #region
        public List<Plan> Get_All_Plan(string login)
        {
            if ((_ctx.Set<User>().FirstOrDefault(u => u.Login == login).Rang_of_User.Id) == _ctx.Set<Rang_of_User>().FirstOrDefault(r => r.Rang == "Senior").Id)
            {
                return _ctx.Set<Plan>().ToList();
            }
            else
            {
                return _ctx.Set<Plan>().Where(pr => pr.User.Id == (_ctx.Set<User>().FirstOrDefault(u => u.Login == login)).Id).ToList();
            }
        }
        public void Save_New_Plan(DateTime date, Decimal sum, string description, string Type, string login)
        {
            Plan expence = new Plan()
            {
                Date_ = date,
                Sum = sum,
                User = _ctx.Set<User>().FirstOrDefault(u => u.Login == login),
                Expense_Type = _ctx.Set<Expence_Type>().FirstOrDefault(p => p.Name == Type),
                Description = description
            };
            _ctx.Set<Plan>().Add(expence);
            _ctx.SaveChanges();
        }
        public void Delete_Plan(Plan plan)
        {
            if (plan.Expense_Type == null)
            {
                plan.Expense_Type = _ctx.Set<Expence_Type>().FirstOrDefault(e => e.Name == "NONE!");
            }
            try
            {
                var result = _ctx.Set<Plan>().Single(new PlanComparator(), plan);
                _ctx.Set<Plan>().Remove(result);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        
        #endregion

        //Get Total Sum and Balance
        #region
        public decimal Get_Total_Profits()
        {
            return _ctx.Set<Profit>().Sum(p => p.Sum);
        }
        public decimal Get_Total_Expences()
        {
            return _ctx.Set<Expense>().Sum(p => p.Sum);
        }
        public decimal Get_Total_Plans()
        {
            return _ctx.Set<Plan>().Sum(p => p.Sum);
        }
        public decimal Get_Balance()
        {
            return (_ctx.Set<Profit>().Sum(p => p.Sum)) - (_ctx.Set<Expense>().Sum(p => p.Sum));
        }

        #endregion

        //Authorization
        public bool Authorization(string login, string parol)
        {
            if (_ctx.Set<User>().FirstOrDefault(u => u.Login == login && u.Password_ == parol) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Create_New_User(string login, string password)
        {
            int count = _ctx.Set<User>().Count();
            if (_ctx.Set<User>().FirstOrDefault(u => u.Login == login) == null)
            {
                User user = new User
                {
                    Login = login,
                    Password_ = password,
                    Rang_of_User = _ctx.Set<Rang_of_User>().FirstOrDefault(r => r.Rang == "Junior")
                };
                _ctx.Set<User>().Add(user);
                _ctx.SaveChanges();
            }
            if (_ctx.Set<User>().Count() > count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Types
        public List<string> GetExpanceTypes()
        {
            var expance_types = _ctx.Set<Expence_Type>().Select(pr => pr.Name.ToString()).ToList();
            return expance_types;
        }
        public List<string> GetProfitsTypes()
        {
            return _ctx.Set<Profit_Type>().Select(pr => pr.Name.ToString()).ToList();
        }
        public void DeleteUser(string login)
        {
            var user = _ctx.Set<User>().Where(x => x.Login == login).SingleOrDefault();
            _ctx.Set<User>().Remove(user);
            _ctx.SaveChanges();
        }
        public void ChangeUser_Login(string login, string newLogin)
        {
            var user = _ctx.Set<User>().Where(x => x.Login == login).SingleOrDefault();
            user.Login = newLogin;
            _ctx.SaveChanges();
        }
        public void ChangeUser_Password(string login, string newPassword)
        {
            var user = _ctx.Set<User>().Where(x => x.Login == login).SingleOrDefault();
            user.Password_ = newPassword;
            _ctx.SaveChanges();
        }
        public void ChangeUser_Status(string login, string newStatus)
        {
            var user = _ctx.Set<User>().Where(x => x.Login == login).SingleOrDefault();
            var rang = _ctx.Set<Rang_of_User>().Where(x => x.Rang == newStatus).SingleOrDefault();
            user.Rang_of_User = rang;
            _ctx.SaveChanges();
        }
        public List<Diary> Diary_ByDate(string login, DateTime date1, DateTime date2)
        {
            return Get_All_Notes(login).Where(x => x.Date.Date >= date1.Date && x.Date.Date <= date2.Date).ToList();

        }
        public Dictionary<string, decimal> Get_Sum_byType_forChart_Profits()
        {
           var dictionary = new Dictionary<string, decimal>();
            foreach (Profit_Type item in _ctx.Set<Profit>().Select(p => p.Profit_Type) )
            {
               dictionary.Add(item.Name, _ctx.Set<Profit>().Where(p=>p.Profit_Type == item).Sum(s => s.Sum));
            }
            return dictionary;
        }
    }
}

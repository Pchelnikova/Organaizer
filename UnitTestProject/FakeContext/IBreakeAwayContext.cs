using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public interface IBreakAwayContext
    {
        IDbSet<Diary> Diary_Fake { get; }
        IDbSet<Profit> Profits_Fake { get; }
        IDbSet<Expense> Expenses_Fake { get; }
        IDbSet<Plan> Plans_Fake { get; }
        IDbSet<Wish> Wishes_Fake { get; }

        int SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace UnitTestProject
{
    public class BreakeAwayContext : DbContext, IBreakAwayContext
    {
        public IDbSet<Diary> Diary_Fake { get; set; }

        public IDbSet<Profit> Profits_Fake { get; set; }

        public IDbSet<Expence> Expenses_Fake { get; set; }

        public IDbSet<Plan> Plans_Fake { get; set; }

        public IDbSet<Wish> Wishes_Fake { get; set; }
    }
}

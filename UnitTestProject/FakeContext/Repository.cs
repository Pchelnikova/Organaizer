using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class Repository
    {
        IBreakAwayContext _context;
        public Repository(IBreakAwayContext context)
        {
            _context = context;
        }

    }
}
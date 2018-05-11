using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organaizer.Model_Classes
{
    public class Profit
    {
        public int Id { get; set; }
        public DateTime Date_ { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }

        //EF navigation properties
        public virtual Profit_Type Profit_Type { get; set; } 
        public virtual User User { get; set; } 
    }
}

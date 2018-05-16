using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model_Classes
{
    //finance plan for future month
    public class Budjet_plan 
    {
        public int Id { get; set; }
        public DateTime Date_ { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }

        //EF navigation properties
        public virtual Expence_Type Expance_Type { get; set; } 
        public virtual User User { get; set; } 
    }
}

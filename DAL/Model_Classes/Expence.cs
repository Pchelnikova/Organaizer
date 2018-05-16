using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model_Classes
{
    public class Expence 
    {
        public int Id { get; set; }
        public DateTime Date_ { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }

        //EF navigation property
        public virtual Expence_Type Expence_Type { get; set; } 
        public virtual User User { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organaizer.Model_Classes
{
    public class Expance 
    {
        public int Id { get; set; }
        public DateTime Date_ { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }

        //EF navigation property
        public virtual Expance_Type Expance_Type { get; set; } 
        public virtual User User { get; set; } 
    }
}

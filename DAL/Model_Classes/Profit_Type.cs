using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model_Classes
{
    public class Profit_Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //EF navigation property
        public virtual ICollection<Profit> Profits { get; set; } 
    }
}

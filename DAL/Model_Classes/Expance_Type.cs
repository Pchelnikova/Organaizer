using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model_Classes
{
    public class Expance_Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //EF navigation properties
        public virtual ICollection<Expance> Expances { get; set; }
        public virtual ICollection<Budjet_plan> Budjet_plan { get; set; }
    }
}

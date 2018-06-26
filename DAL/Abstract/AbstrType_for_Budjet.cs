using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class AbstrType_for_Budjet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //EF navigation property
        public virtual ICollection<Budjet_Unit> Budjet_Units { get; set; }
    }
}

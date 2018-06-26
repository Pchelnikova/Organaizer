using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class Budjet_Unit
    {
        public int Id { get; set; }
        public DateTime Date_ { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }
        public virtual AbstrType_for_Budjet AbstrType_for_Budget { get; set; }
        public virtual User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Expence_Type : AbstrType_for_Budjet
    {        
        //EF navigation properties
        public virtual ICollection<Plan> Plan { get; set; }
    }
}

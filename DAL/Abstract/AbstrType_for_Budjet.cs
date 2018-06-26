using System.Collections.Generic;

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

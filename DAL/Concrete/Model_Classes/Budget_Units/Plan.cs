namespace DAL
{
    //finance plan for future month
    public class Plan : Budjet_Unit
    {
        //EF navigation properties
        public virtual Expence_Type Expance_Type { get; set; } 
    }
}

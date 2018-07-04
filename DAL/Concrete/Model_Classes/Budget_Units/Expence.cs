namespace DAL
{
    public class Expense : Budjet_Unit
    {
        //EF navigation property
        public virtual Expence_Type Expence_Type { get; set; } 
    }
}

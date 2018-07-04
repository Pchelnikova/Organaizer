namespace DAL
{
    //finance plan for future month
    public class Plan : Budjet_Unit
    {
        //EF navigation properties
        public virtual Expence_Type Expense_Type { get; set; } 
    }
}

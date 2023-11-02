namespace Web.Areas.Employee.Models
{
    public class ExpenseListViewModel
    {
        public List<GetExpenseViewModel> Expenses { get; set; } = new();
    }
}
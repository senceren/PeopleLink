using ApplicationCore.Entities;
using ApplicationCore.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Areas.Employee.Models;

namespace Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ExpenseController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExpenseController(HttpClient httpClient, UserManager<ApplicationUser> userManager)
        {
            _httpClient = httpClient;
            _userManager = userManager;
        }
        public async Task<IActionResult> AllExpenses(string? status)
        {
            var user = await _userManager.GetUserAsync(User);
            var employeeId = _userManager.GetUserId(User);
            TempData["Picture"] = (await _userManager.GetUserAsync(User))!.PictureUri;
            string apiUrl = $"https://localhost:7167/api/Expense?employeeId={employeeId}";
            string apiUrlWithStatus = $"https://localhost:7167/api/Expense?status={status}&employeeId={employeeId}";
            NameMethod(user);

            ViewBag.Status = status;

            if (status != null)
            {
                var expensesWithStatus = await _httpClient.GetFromJsonAsync<List<GetExpenseViewModel>>(apiUrlWithStatus);
                return View(expensesWithStatus);

            }

            var expenses = await _httpClient.GetFromJsonAsync<List<GetExpenseViewModel>>(apiUrl);
            return View(expenses);
        }

        public async Task<IActionResult> ExpenseRequest()
        {
            var user = await _userManager.GetUserAsync(User);
            var expensesTypes = Enum.GetValues(typeof(ExpenseType)).Cast<ExpenseType>().ToList();
            var currencyTypes = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();
            ViewBag.ExpenseTypes = expensesTypes;
            ViewBag.CurrentTypes = currencyTypes;
            ViewData["EmployeeId"] = user!.Id;
            TempData["Picture"] = (await _userManager.GetUserAsync(User))!.PictureUri;
            NameMethod(user);
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ExpenseRequest(PostExpenseViewModel expenseViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            string apiUrl = $"https://localhost:7167/api/Expense?&employeeId={user.Id}";
            var expenses = await _httpClient.GetFromJsonAsync<List<GetExpenseViewModel>>(apiUrl);
            var expensesTypes = Enum.GetValues(typeof(ExpenseType)).Cast<ExpenseType>().ToList();
            var currencyTypes = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();
            ViewBag.ExpenseTypes = expensesTypes;
            ViewBag.CurrentTypes = currencyTypes;
            NameMethod(user);

            if (ModelState.IsValid)
            {
                string ext = Path.GetExtension(expenseViewModel.Document.FileName);
                string fileName = Path.Combine(Guid.NewGuid().ToString() + ext);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/document", fileName);

                using (var fileStream = System.IO.File.Create(filePath))
                {
                    expenseViewModel.Document.CopyTo(fileStream);
                }

                var expense = new AddExpenseViewModel()
                {
                    EmployeeId = expenseViewModel.EmployeeId,
                    Currency = expenseViewModel.Currency,
                    Amount = expenseViewModel.Amount,
                    ExpenseType = expenseViewModel.ExpenseType,
                    DocumentUri = fileName,

                };

                await _httpClient.PostAsJsonAsync("https://localhost:7167/api/Expense/", expense);

                TempData["SuccessExpense"] = "Harcama talebi başarıyla oluşturuldu.";
                return RedirectToAction("AllExpenses");

            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExpense(int expenseId)
        {

            var expense = await _httpClient.GetFromJsonAsync<GetExpenseViewModel>($"https://localhost:7167/api/Expense/{expenseId}");

            var user = await _userManager.GetUserAsync(User);
            NameMethod(user);

            await _httpClient.DeleteAsync($"https://localhost:7167/api/Expense/{expenseId}");
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/document", expense!.DocumentUri);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            };

            TempData["DeleteSuccessExpense"] = "Harcama talebi başarıyla silindi.";
            return RedirectToAction("AllExpenses");
        }
        private void NameMethod(ApplicationUser? user)
        {
            TempData["Name"] = user.FirstName + " " + (user.MiddleName != null ? user.MiddleName : "") + (user.MiddleLastName != null ? user.MiddleLastName : "") + " " + user.LastName;
            TempData["Picture"] = user.PictureUri;
        }
    }
}

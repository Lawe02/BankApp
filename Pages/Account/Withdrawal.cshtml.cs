using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperLibrary.Services;

namespace NorthWindApp.Pages.Account
{
    public class WithdrawalModel : PageModel
    {
        private readonly AccountServices _service;

        public WithdrawalModel(AccountServices service)
        {
            _service = service;
        }
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public void OnGet(int id)
        {
            var acc = _service.GetAccount(id);

            Id = acc.AccountId;
            Balance = acc.Balance;
        }

        public IActionResult OnPost(decimal amount, int id)
        {
            var acc = _service.GetAccount(id);
            _service.MakeWithdrawal(amount, acc);

            return RedirectToPage("Index", new { id });

        }
    }
}

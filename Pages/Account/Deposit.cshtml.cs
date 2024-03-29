using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperLibrary.Services;

namespace NorthWindApp.Pages.Account
{

    [Authorize(Roles ="Admin")]
    public class DepositModel : PageModel
    {

        private readonly IAccountService _service;
        public DepositModel(IAccountService service)
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

        public IActionResult OnPost(int id, decimal amount)
        {
            var acc = _service.GetAccount(id);
            _service.MakeDeposit(amount, acc);

            return RedirectToPage("Index", new { id });
        }
    }
}

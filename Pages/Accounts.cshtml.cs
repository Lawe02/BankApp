using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthWindApp.Models;
using NorthWindApp.Pages.ViewModels;
using NorthWindApp.Services;

namespace NorthWindApp.Pages
{
    public class AccountsModel : PageModel
    {
        private readonly AccountServices _accServices;
        public AccountsModel(AccountServices accServices)
        {
            _accServices = accServices;
        }
        public List<dynamic> Accounts { get; set; }
        public void OnGet(string sortColumn, string sortOrder)
        {
            Accounts = _accServices.GetAccounts(sortColumn, sortOrder);
        }
    }
}

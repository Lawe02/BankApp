using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperLibrary.Models;
using SuperLibrary.ViewModels;
using SuperLibrary.Services;

namespace NorthWindApp.Pages
{
    [Authorize(Roles = "Admin")]
    public class AccountsModel : PageModel
    {
        private readonly AccountServices _accServices;
        public AccountsModel(AccountServices accServices)
        {
            _accServices = accServices;
        }
        public int PageNr { get; set; } = 1;
        public List<AccountViewModel> Accounts { get; set; } 
        public string Q { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public void OnGet(string sortColumn, string sortOrder, int pageNr, string q)
        {
            if (pageNr != 0)
                PageNr = pageNr;
            else
                PageNr = 1;

            if (sortColumn != null)
                SortColumn = sortColumn;

            if (sortOrder != null)
                SortOrder = sortOrder;

            if (q != null)
                Q = q;

            Accounts = _accServices.GetAccounts(SortColumn, SortOrder, PageNr, Q);
        }
    }
}

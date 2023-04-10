using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthWindApp.Models;
using NorthWindApp.Pages.ViewModels;
using NorthWindApp.Services;

namespace NorthWindApp.Pages.Shared
{
    [Authorize(Roles = "Admin")]
    public class CustomersModel : PageModel
    {
        private readonly CustomerServices _cusService;

        public CustomersModel(CustomerServices service)
        {
            _cusService = service;
        }
        public int PageNr { get; set; } = 1;
        public List<CustomerViewModel> Customers { get; set; }
        public string Q { get; set; }
        public string SortOrder { get; set; }
        public string SortColumn { get; set; }
        public void OnGet(string sortColumn, string sortOrder, string q, int pageNr)
        {
            if (pageNr != 0)
                PageNr = pageNr;
            else
                PageNr = 1;

            if (q != null)
                Q = q;

            if (sortColumn != null)
                SortColumn = sortColumn;

            if(sortOrder != null)
                SortOrder = sortOrder;

            Customers = _cusService.GetCustomers(SortColumn, SortOrder, Q, PageNr);

        }
    }
}

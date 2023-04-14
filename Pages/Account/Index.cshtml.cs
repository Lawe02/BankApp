using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperLibrary.Services;
using SuperLibrary.Models;
using SuperLibrary.ViewModels;

namespace NorthWindApp.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly AccountServices _service;
        public IndexModel (AccountServices service)
        {
            _service = service;
        }
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public DateTime Created { get; set; }
        public string Frequency { get; set; }
        public void OnGet(int id)
        {
            var acc = _service.GetAccount(id);

            Id = acc.AccountId;
            Balance = acc.Balance;
            Created = acc.Created;
            Frequency = acc.Frequency;
            
        }
    }
}

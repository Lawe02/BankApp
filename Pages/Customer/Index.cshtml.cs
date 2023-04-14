using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperLibrary.Services;

namespace NorthWindApp.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _cusService;

        public IndexModel(ICustomerService service)
        {
            _cusService = service;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }  
        public int Id { get; set; }
        public List<SuperLibrary.Models.Account> Accounts { get; set; }
        public void OnGet(int id)
        {
            var customer = _cusService.GetCustomer(id);

            Name = customer.Givenname;
            Address = customer.Streetaddress;
            City = customer.City;
            Id = customer.CustomerId;
            Accounts = _cusService.GetCustomerAccounts(Id);
        }
    }
}

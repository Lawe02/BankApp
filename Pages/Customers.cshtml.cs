using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthWindApp.Models;
using NorthWindApp.Pages.ViewModels;

namespace NorthWindApp.Pages.Shared
{
    public class CustomersModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;

        public CustomersModel(BankAppDataContext context)
        {
            _dbContext = context;
        }
        public List<CustomerViewModel> Customers { get; set; }
        public void OnGet(string sortColumn, string sortOrder)
        {
            var query = _dbContext.Customers
                .Select(x=> new CustomerViewModel() 
                { 
                    Address = x.Streetaddress,
                    Id = x.CustomerId,
                    Name = x.Givenname
                });

            if (sortColumn == "Address")
                if (sortOrder == "asc")
                    query = query.OrderBy(x => x.Address);
                else
                    query = query.OrderByDescending(x => x.Address);

            if (sortColumn == "Id")
                if (sortOrder == "asc")
                    query = query.OrderBy(x => x.Id);
                else
                    query = query.OrderByDescending(x => x.Id);

            if (sortColumn == "Name")
                if (sortOrder == "asc")
                    query = query.OrderBy(x => x.Name);
                else
                    query = query.OrderByDescending(x => x.Name);

            Customers = query.ToList();

        }
    }
}

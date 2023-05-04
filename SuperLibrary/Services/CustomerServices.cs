using Microsoft.EntityFrameworkCore;
using SuperLibrary.Models;
using SuperLibrary.ViewModels;

namespace SuperLibrary.Services
{
    public class CustomerServices : ICustomerService
    {
        private readonly BankAppDataContext _dbContext;
        public CustomerServices(BankAppDataContext context)
        {
            _dbContext = context;
        }

        public List<CustomerViewModel> GetCustomers(string sortColumn, string sortOrder, string q, int pageNr)
        {
            var query = _dbContext.Customers
            .Select(x => new CustomerViewModel()
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

            if (q != null)
                query = query.Where(x => x.Address.Contains(q)
                            || x.Id.ToString().Contains(q)
                            || x.Name.Contains(q));

            query = query.Skip((pageNr - 1) * 50)
                .Take(50);

            return query.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _dbContext.Customers.First(x => x.CustomerId == id);
        }
        public List<Account> GetCustomerAccounts(int id)
        {
            var accounts = _dbContext.Accounts.Include(x => x.Dispositions).Where(x => x.AccountId == id).ToList();
            return accounts;
        }
    }
}

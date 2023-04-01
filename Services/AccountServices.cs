using NorthWindApp.Models;
using NorthWindApp.Pages.ViewModels;

namespace NorthWindApp.Services
{
    public class AccountServices : IAccountService
    {
        private readonly BankAppDataContext _context;

        public AccountServices(BankAppDataContext context)
        {
            _context = context;
        }
        public List<dynamic> GetAccounts(string sortColumn, string sortOrder)
        {
            var query = _context.Accounts
                .Select(x => new 
                {
                    Balance = x.Balance,
                    Created = x.Created,
                    Frequency = x.Frequency,
                    Id = x.AccountId
                });

            if (sortColumn == "Id")
                if (sortOrder == "asc")
                    query = query.OrderBy(x => x.Id);
                else
                    query = query.OrderByDescending(x => x.Id);

            if (sortColumn == "Balance")
                if (sortOrder == "asc")
                    query = query.OrderBy(x => x.Balance);
                else
                    query = query.OrderByDescending(x => x.Balance);

            if (sortColumn == "Created")
                if (sortOrder == "asc")
                    query = query.OrderBy(x => x.Created);
                else
                    query = query.OrderByDescending(x => x.Created);

            if (sortColumn == "Frequency")
                if (sortOrder == "asc")
                    query = query.OrderBy(x => x.Frequency);
                else
                    query = query.OrderByDescending(x => x.Frequency);

            return query.ToList<dynamic>();

        }
    }
}

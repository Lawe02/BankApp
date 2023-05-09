using SuperLibrary.Models;
using SuperLibrary.ViewModels;

namespace SuperLibrary.Services
{
    public interface ICustomerService
    {
        public List<CustomerViewModel> GetCustomers(string sortColumn, string sortOrder, string q, int pageNr);
        public List<Account> GetCustomerAccounts(int id);
        public Customer GetCustomer(int id);
    }
}

using NorthWindApp.Pages.ViewModels;

namespace NorthWindApp.Services
{
    public interface ICustomerService
    {
        public List<CustomerViewModel> GetCustomers(string sortColumn, string sortOrder, string q, int pageNr);
    }
}

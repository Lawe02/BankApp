using NorthWindApp.Pages.ViewModels;

namespace NorthWindApp.Services
{
    public interface IAccountService
    {
        List<dynamic> GetAccounts(string sortColumn, string sortOrder);
    }
}

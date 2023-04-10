using NorthWindApp.Pages.ViewModels;
using NorthWindApp.Models;

namespace NorthWindApp.Services
{
    public interface IAccountService
    {
        List<dynamic> GetAccounts(string sortColumn, string sortOrder, int pageNr, string q);
        public Account GetAccount(int id);
    }
}

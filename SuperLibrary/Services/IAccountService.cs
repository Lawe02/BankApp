using SuperLibrary.ViewModels;
using SuperLibrary.Models;

namespace SuperLibrary.Services
{
    public interface IAccountService
    {
        List<AccountViewModel> GetAccounts(string sortColumn, string sortOrder, int pageNr, string q);
        public Account GetAccount(int id);
        public void MakeDeposit(decimal sum, Account acc);
        public void MakeWithdrawal(decimal sum, Account acc);
    }
}

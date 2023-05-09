using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperLibrary.ViewModels;

namespace SuperLibrary.Services
{
    public interface ICountryService
    {
        public int TotalAssets(string country);
        public int TotalAccounts(string country);
        public int TotalClients(string country);
        public List<TopTenViewModel> TopTenAccounts(string country);
    }
}
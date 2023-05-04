using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperLibrary.Models;
using SuperLibrary.ViewModels;

namespace SuperLibrary.Services
{
    public class CountryService : ICountryService
    {
        private readonly BankAppDataContext _context;
        public CountryService(BankAppDataContext context)
        {
            _context = context;
        } 

        public int TotalAssets(string country){
            var total = _context.Dispositions.Include(x => x.CustomerId)
                                             .Include(x => x.AccountId)
                                             .Where(x => x.Customer.CountryCode == country)
                                             .Sum(x => x.Account.Balance);
            Console.WriteLine(total);
            return (int)total;
        }

        public int TotalAccounts(string country){
            var total = _context.Dispositions.Include(x => x.AccountId)
                                             .Include(x => x.CustomerId)
                                             .Where(x=> x.Customer.CountryCode == country)
                                             .Count(x => x.Account.AccountId == x.AccountId);
            return total;
        }      

        public int TotalClients(string country){
            var total = _context.Dispositions.Include(x => x.AccountId)
                                             .Include(x => x.CustomerId)
                                             .Count(x => x.Customer.CountryCode == country);
                                             
            return total;
        }

        public List<TopTenViewModel> TopTenAccounts(string country){
            var topTen = _context.Dispositions.Include(x => x.AccountId)
                                              .Include(x => x.CustomerId)
                                              .Where(x => x.Customer.CountryCode == country)
                                              .OrderByDescending(x => x.Account.Balance)
                                              .Take(10)
                                              .Select(x => new TopTenViewModel() {Id = x.Account.AccountId, Name = x.Customer.Givenname, Email = x.Customer.Emailaddress, Balance = x.Account.Balance })
                                              .ToList();
            return topTen;
        }
    }
}
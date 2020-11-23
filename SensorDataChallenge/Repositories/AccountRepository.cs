using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Data;
using SensorDataChallenge.Interfaces;
using SensorDataChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Repositories
{
    public class AccountRepository : GenericRepository<ApplicationUser>, IAccountRepository
    {
        public AccountRepository(SensorDataDbContext context) : base(context)
        {
        }
    }
}

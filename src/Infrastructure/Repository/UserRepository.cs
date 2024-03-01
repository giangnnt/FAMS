using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAMS.src.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace net03_group02.src.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FAMSContext _dbContext;
        public UserRepository(FAMSContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<User?> GetUserByEmailAsync(string email)
        {
            return _dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
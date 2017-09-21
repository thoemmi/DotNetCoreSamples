using SelfHosted.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SelfHosted.Models.Domain;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SelfHosted.DataAccess.SqlDataContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SelfHosted.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<User> Create(User user)
        {
            if (user == null || !user.IsValid())
                throw new ArgumentException("the user object is null or not valid.");

            if ((await _context.Users.AnyAsync(m => m.Firstname == user.Firstname && m.LastName == user.LastName)))
                throw new ApplicationException($"user with the name '{user.LastName}, {user.Firstname}' already exists");

            var result = _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<User>> Get(Expression<Func<User, bool>> predicate)
        {
            if (predicate == null)
                return await _context.Users.ToListAsync();

            return await _context.Users.Where(predicate).ToListAsync();
        }

        public async Task<bool> Remove(User user)
        {
            if (user == null && user.UserId != 0)
                throw new ArgumentException("the user object is null or not valid.");

            if ((await _context.Users.AnyAsync(m => m.UserId == user.UserId)) == false)
                throw new ApplicationException($"user '{user.UserId}: {user.LastName}, {user.Firstname}' doesnt exists");

            try
            {
                var userForDelete = await _context.Users.FirstOrDefaultAsync(m => m.UserId == user.UserId);
                _context.Users.Remove(userForDelete);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception)
            {
                //Todo: Log exception

                return false;
            }

        }
    }
}

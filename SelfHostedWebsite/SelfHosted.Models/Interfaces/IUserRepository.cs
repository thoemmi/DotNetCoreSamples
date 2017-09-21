using SelfHosted.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SelfHosted.Models.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);

        Task<bool> Remove(User user);

        Task<IEnumerable<User>> Get(Expression<Func<User, bool>> predicate);
    }
}

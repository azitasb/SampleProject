using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sabahat.Data.Users;

namespace Sabahat.Business.Users
{
    public interface IUserBusiness
    {
        List<User> GetUsers();
        List<User> PostUsers(List<User> users);
    }
}

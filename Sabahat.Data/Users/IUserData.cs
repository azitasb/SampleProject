using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabahat.Data.Users
{
    public interface IUserData
    {
        List<User> GetUsers();
        List<User> PostUsers(List<User> users);
    }
}

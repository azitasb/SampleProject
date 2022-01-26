using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sabahat.Data.Users;

namespace Sabahat.Business.Users
{
    public class UserBusiness :IUserBusiness
    {
        private IUserData _userData;

        public UserBusiness(IUserData userData)
        {
            _userData = userData;
        }

        public List<User> GetUsers()
        {
            return _userData.GetUsers();
        }

        public List<User> PostUsers(List<User> users)
        {
            return _userData.PostUsers(users);
        }

    }
}

using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IRepository
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel GetDetail(int Id);

        UserModel CheckLogin(string username, string password);

        int ModifyPwd(PassWordModel model);
    }
}

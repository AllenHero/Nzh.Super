using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IService
{
    public interface IUserService : IBaseService<UserModel>
    {
        UserModel GetDetail(int Id);

        UserModel CheckLogin(string username, string password);

        bool ModifyPwd(PassWordModel model);

        bool InitPwd(UserModel model);
    }
}

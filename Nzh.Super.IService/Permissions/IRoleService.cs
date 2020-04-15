using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IService
{
    public interface IRoleService : IBaseService<RoleModel>
    {
        IEnumerable<RoleModel> GetRoleList();

        bool DeleteRoleAllByRoleId(int roleId);
    }
}

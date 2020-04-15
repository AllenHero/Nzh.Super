using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IRepository
{
    public interface IRoleRepository : IBaseRepository<RoleModel>
    {
        IEnumerable<RoleModel> GetRoleList();

        bool DeleteRoleAllByRoleId(int roleId);
    }
}

using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IRepository
{
    public interface IMenuRoleActionRepository : IBaseRepository<MenuRoleActionModel>
    {
        int SavePermission(IEnumerable<MenuRoleActionModel> entitys, int roleId);
    }
}

using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IService
{
    public interface IMenuRoleActionService : IBaseService<MenuRoleActionModel>
    {
        int SavePermission(IEnumerable<MenuRoleActionModel> entitys, int roleId);

        IEnumerable<MenuRoleActionModel> GetListByRoleIdMenuId(int roleId, int menuId);
    }
}

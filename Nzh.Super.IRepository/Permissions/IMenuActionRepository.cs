using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IRepository
{
    public interface IMenuActionRepository : IBaseRepository<MenuActionModel>
    {
        int SavePermission(IEnumerable<MenuActionModel> entitys, int menuId);
    }
}

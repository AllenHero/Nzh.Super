using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IService
{
    public interface IMenuActionService : IBaseService<MenuActionModel>
    {
        int SavePermission(IEnumerable<MenuActionModel> entitys, int menuId);
    }
}

using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IService
{
    public interface IMenuService : IBaseService<MenuModel>
    {
        dynamic GetMenusList(bool isIndex, int roleId);

        string GetParentMenuName(int Id);

        IEnumerable<MenuModel> GetAvailableMenuList(int roleId);

        bool DeleteMenuAllByMenuId(int menuId);
    }
}

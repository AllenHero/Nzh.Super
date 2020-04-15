using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IRepository
{
    public interface IMenuRepository : IBaseRepository<MenuModel>
    {
        MenuModel GetParentMenu(string sql, int Id);

        IEnumerable<MenuModel> GetAvailableMenuList(string sql);

        IEnumerable<MenuModel> GetMenuListByRoleId(string sql, int roleId);

        bool DeleteMenuAllByMenuId(int menuId);
    }
}

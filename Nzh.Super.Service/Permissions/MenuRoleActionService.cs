using Nzh.Super.IRepository;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.Service
{
    public class MenuRoleActionService : BaseService<MenuRoleActionModel>, IMenuRoleActionService
    {
        public IMenuRoleActionRepository repository { get; set; }

        public int SavePermission(IEnumerable<MenuRoleActionModel> entitys, int roleId)
        {
            return repository.SavePermission(entitys, roleId);
        }
        public IEnumerable<MenuRoleActionModel> GetListByRoleIdMenuId(int roleId, int menuId)
        {
            string sql = " where RoleId=@RoleId and MenuId=@MenuId";
            return repository.GetByWhere(sql, new { RoleId = roleId, MenuId = menuId });
        }

        public dynamic GetListByFilter(MenuRoleActionModel filter, PageInfo pageInfo)
        {
            return GetListByFilter(filter, pageInfo, "");
        }
    }
}

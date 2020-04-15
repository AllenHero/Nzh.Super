using Nzh.Super.IRepository;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.Service
{
    public class MenuActionService : BaseService<MenuActionModel>, IMenuActionService
    {
        public IMenuActionRepository repository { get; set; }

        public int SavePermission(IEnumerable<MenuActionModel> entitys, int menuId)
        {
            return repository.SavePermission(entitys, menuId);
        }

        public dynamic GetListByFilter(MenuActionModel filter, PageInfo pageInfo)
        {
            return GetListByFilter(filter, pageInfo, "");
        }
    }
}

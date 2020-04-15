using Nzh.Super.Common;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IRepository
{
    public interface IActionRepository : IBaseRepository<ActionModel>
    {
        IEnumerable<ActionModel> GetActionListByRoleId(int roleId, int menuId, out IEnumerable<ActionModel> selectList);

        IEnumerable<ActionModel> GetActionListByMenuId(int menuId);

        IEnumerable<ActionModel> GetActionListByMenuIdRoleId(int menuId, int roleId, PositionEnum position);

        bool DeleteActionAllByActionId(int actionId);
    }
}

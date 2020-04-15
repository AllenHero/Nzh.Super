using Nzh.Super.Common;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IService
{
    public interface IActionService : IBaseService<ActionModel>
    {
        string GetActionListHtmlByRoleId(int roleId, int menuId);

        IEnumerable<ActionModel> GetActionListByMenuId(int menuId);

        IEnumerable<ActionModel> GetActionListByMenuIdRoleId(int menuId, int roleId, PositionEnum position);

        bool DeleteActionAllByActionId(int actionId);
    }
}

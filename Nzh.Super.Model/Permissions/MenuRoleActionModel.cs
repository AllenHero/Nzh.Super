using Nzh.Super.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.Model
{
    [Table("t_menu_role_action")]
    public class MenuRoleActionModel
    {
        public int MenuId { get; set; }

        public int ActionId { get; set; }

        public int RoleId { get; set; }
    }
}

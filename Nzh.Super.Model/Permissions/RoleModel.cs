using Nzh.Super.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nzh.Super.Model
{
    [Table("t_Role")]
    public class RoleModel : Entity
    {
        [Display(Name = "角色编码")]
        public string RoleCode { get; set; }

        [Display(Name = "角色名称")]
        public string RoleName { get; set; }

        [Display(Name = "角色描述")]
        public string Remark { get; set; }
    }
}

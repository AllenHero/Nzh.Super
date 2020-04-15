using Nzh.Super.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nzh.Super.Model
{
    [Table("t_User")]
    public class UserModel : Entity
    {
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "真实名称")]
        public string RealName { get; set; }

        public string PassWord { get; set; }

        public int RoleId { get; set; }

        [Display(Name = "性别")]
        public int Gender { get; set; }

        [Display(Name = "手机")]
        public string Phone { get; set; }

        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }

        [Display(Name = "头像")]
        public string HeadShot { get; set; }

        [Computed]
        [Display(Name = "角色名称")]
        public string RoleName { get; set; }
    }
}

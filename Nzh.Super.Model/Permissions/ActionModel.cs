using Nzh.Super.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nzh.Super.Model
{
    [Table("t_Action")]
    public class ActionModel : Entity
    {
        [Display(Name = "操作编码")]
        public string ActionCode { get; set; }

        [Display(Name = "操作名称")]
        public string ActionName { get; set; }

        [Display(Name = "显示位置")]
        public int Position { get; set; }

        public string Icon { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }

        [Display(Name = "操作方法")]
        public string Method { get; set; }

        [Display(Name = "排序号")]
        public int OrderBy { get; set; }

        [Display(Name = "样式名称")]
        public string ClassName { get; set; }
    }
}

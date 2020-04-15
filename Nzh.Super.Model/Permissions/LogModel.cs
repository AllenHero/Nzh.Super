using Nzh.Super.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.Model
{
    [Table("t_Log")]
    public class LogModel : Entity
    {
        public string LogType { get; set; }

        public string RealName { get; set; }

        public string UserName { get; set; }

        public string Description { get; set; }

        public string ModuleName { get; set; }

        public string IPAddress { get; set; }

        public string IPAddressName { get; set; }

        [Computed]
        public override DateTime UpdateOn { get; set; }

        [Computed]
        public override int UpdateBy { get; set; }

        [Computed]
        public override int CreateBy { get; set; }
    }
}

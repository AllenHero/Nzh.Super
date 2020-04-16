using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzh.Super.Models
{
    public class WebSiteModel
    {
        public string SiteName { get; set; }
        public string SiteDomain { get; set; }
        public string CacheTime { get; set; }
        public string MaxFileUpload { get; set; }
        public string UploadFileType { get; set; }
        public string HomeTitle { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescribe { get; set; }
        public string CopyRight { get; set; }
    }
}

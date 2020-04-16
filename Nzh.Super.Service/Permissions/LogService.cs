using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.Service
{
    public class LogService : BaseService<LogModel>, ILogService
    {
        public bool WriteDbLog(LogModel model, string ip, string iPAddressName)
        {
            model.Status = true;
            model.CreateOn = DateTime.Now;
            model.IPAddress = ip;
            model.IPAddressName = iPAddressName;
            return baseRepository.Create(model) > 0 ? true : false;
        }

        public dynamic GetListByFilter(LogModel filter, PageInfo pageInfo)
        {
            string _where = " where 1=1";
            if (!string.IsNullOrEmpty(filter.RealName))
            {
                _where += " and RealName=@RealName";
            }
            if (!string.IsNullOrEmpty(filter.UserName))
            {
                _where += " and UserName=@UserName";
            }
            _where = CreateWhereStr(filter, _where);
            return GetListByFilter(filter, pageInfo, _where);
        }
    }
}

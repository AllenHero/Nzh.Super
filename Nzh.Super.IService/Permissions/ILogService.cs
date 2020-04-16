using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.IService
{
    public interface ILogService : IBaseService<LogModel>
    {
        bool WriteDbLog(LogModel model, string ip, string iPAddressName);
    }
}

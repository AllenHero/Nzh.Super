using Nzh.Super.Extension.SQLExts.MySQLExt;
using Nzh.Super.IRepository;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nzh.Super.Repository
{
    public class MenuActionRepository : BaseRepository<MenuActionModel>, IMenuActionRepository
    {
        public int SavePermission(IEnumerable<MenuActionModel> entitys, int menuId)
        {
            var result = 0;
            using (var conn = MySqlHelper.GetConnection())
            {
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    conn.DeleteByWhere<MenuActionModel>(" where MenuId=@MenuId", new { MenuId = menuId }, transaction);
                    if (entitys != null)
                    {
                        conn.InsertBatch<MenuActionModel>(entitys, transaction);
                    }
                    transaction.Commit();
                    result = 1;
                }
                catch (Exception)
                {
                    result = -1;
                    transaction.Rollback();
                }
            }
            return result;
        }
    }
}

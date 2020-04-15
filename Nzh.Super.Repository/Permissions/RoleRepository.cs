using Dapper;
using Nzh.Super.IRepository;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nzh.Super.Repository
{
    public class RoleRepository : BaseRepository<RoleModel>, IRoleRepository
    {
        public IEnumerable<RoleModel> GetRoleList()
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "SELECT Id,RoleName from t_role";
                return conn.Query<RoleModel>(sql);
            }
        }

        public bool DeleteRoleAllByRoleId(int roleId)
        {
            string sql1 = string.Format("DELETE FROM t_role WHERE Id={0}", roleId);
            string sql2 = string.Format("DELETE FROM t_menu_role_action WHERE RoleId={0}", roleId);
            using (var conn = MySqlHelper.GetConnection())
            {
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    conn.Execute(sql1, null, transaction);
                    conn.Execute(sql2, null, transaction);
                    transaction.Commit();
                    return true;
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}

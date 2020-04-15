using Dapper;
using Nzh.Super.IRepository;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nzh.Super.Repository
{
    public class MenuRepository : BaseRepository<MenuModel>, IMenuRepository
    {
        public MenuModel GetParentMenu(string sql, int Id)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                return conn.QueryFirstOrDefault<MenuModel>(sql, new { Id = Id });
            }
        }

        public IEnumerable<MenuModel> GetAvailableMenuList(string sql)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                sql += "  GROUP BY mra.MenuId";
                return conn.Query<MenuModel>(sql);
            }
        }

        public IEnumerable<MenuModel> GetMenuListByRoleId(string sql, int roleId)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                sql += "  where mra.RoleId = @RoleId and m.Status=1 GROUP BY mra.MenuId";
                return conn.Query<MenuModel>(sql, new { RoleId = roleId });
            }
        }

        public bool DeleteMenuAllByMenuId(int menuId)
        {
            string sql1 = string.Format("DELETE FROM t_menu WHERE id={0}", menuId);
            string sql2 = string.Format("DELETE FROM t_menu_action WHERE MenuId={0}", menuId);
            string sql3 = string.Format("DELETE FROM t_menu_role_action WHERE MenuId={0}", menuId);
            using (var conn = MySqlHelper.GetConnection())
            {
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    conn.Execute(sql1, null, transaction);
                    conn.Execute(sql2, null, transaction);
                    conn.Execute(sql3, null, transaction);
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

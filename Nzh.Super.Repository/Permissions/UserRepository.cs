using Dapper;
using Nzh.Super.IRepository;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nzh.Super.Repository
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserModel GetDetail(int Id)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "select u.*,r.RoleName from t_User u INNER JOIN t_role r on u.RoleId=r.Id AND u.Id=@Id";
                return conn.Query<UserModel>(sql, new { Id }).FirstOrDefault();
            }
        }

        public UserModel CheckLogin(string username, string password)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "Select Id,UserName,RealName,CreateOn,PassWord,Status,RoleId,HeadShot from t_User where 1=1 ";
                if (!string.IsNullOrEmpty(username))
                {
                    sql += " and UserName=@UserName";
                }
                if (!string.IsNullOrEmpty(password))
                {
                    sql += " and PassWord=@PassWord";
                }
                return conn.Query<UserModel>(sql, new { UserName = username, PassWord = password }).FirstOrDefault();
            }
        }

        public int ModifyPwd(PassWordModel model)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "update t_User set PassWord=@Password where UserName=@UserName and Password=@OldPassword";
                return conn.Execute(sql, model);
            }
        }
    }
}

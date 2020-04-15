﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nzh.Super.Extension
{
    public static class DapperExtAllSQL
    {
        public static DataTable GetDataTableBase(this IDbConnection conn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (IDataReader reader = conn.ExecuteReader(sql, param, transaction, commandTimeout))
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public static DataSet GetDataSetBase(this IDbConnection conn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (IDataReader reader = conn.ExecuteReader(sql, param, transaction, commandTimeout))
            {
                DataSet ds = new DataSet();
                while (!reader.IsClosed)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    ds.Tables.Add(dt);
                }
                return ds;
            }
        }
    }
}

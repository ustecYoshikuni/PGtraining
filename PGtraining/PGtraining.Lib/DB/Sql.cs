using Dapper.FastCrud;
using System;
using System.Data.SqlClient;
using static PGtraining.Lib.Log.LogLeverl;

namespace PGtraining.Lib.DB
{
    public static class Sql
    {
        public static bool InsertOrder(Import.Template order)
        {
            var log = new Lib.Log.Log();
            var result = false;

            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                try
                {
                    connection.ConnectionString = Setting.Setting.ConnectionString;
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        connection.Insert(order.Order, statement => statement.AttachToTransaction(tran));

                        foreach (var menu in order.MenuList)
                        {
                            connection.Insert(menu, statement => statement.AttachToTransaction(tran));
                        }
                        tran.Commit();
                    }
                }
                catch (Exception ex)
                {
                    log.Write(ex.ToString(), LevelEnum.ERRROR);
                }
            }
            return result;
        }
    }
}
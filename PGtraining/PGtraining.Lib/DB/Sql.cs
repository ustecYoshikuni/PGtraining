using Dapper.FastCrud;
using System;
using System.Data.SqlClient;
using static PGtraining.Lib.Log.LogLeverl;

namespace PGtraining.Lib.DB
{
    public static class Sql
    {
        public static bool HasOrderNo(Order order)
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

                    var orders = connection.Get(order);
                    result = (orders == null) ? false : true;
                }
                catch (Exception ex)
                {
                    log.Write(ex.ToString(), LevelEnum.ERRROR);
                }
            }
            return result;
        }

        public static bool InsertOrder(Import.Template template)
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
                        connection.Insert(template.Order, statement => statement.AttachToTransaction(tran));

                        foreach (var menu in template.MenuList)
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

        public static bool UpdateOrder(Import.Template order)
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
                        connection.Update(order.Order, statement => statement.AttachToTransaction(tran));

                        connection.BulkDelete<Menu>(statement => statement.Where($"{nameof(Menu.OrderNo):C}={order.Order.OrderNo}").AttachToTransaction(tran));

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
using Dapper.FastCrud;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static PGtraining.Lib.Log.LogLeverl;

namespace PGtraining.Lib.DB
{
    public static class Sql
    {
        /// <summary>
        /// 有効期限内のUserIdの情報取得
        /// </summary>
        /// <returns></returns>
        public static User GetUsers(string userId, Setting.Setting setting)
        {
            var log = new Lib.Log.Log();
            var results = new User();
            var now = DateTime.Now;

            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                try
                {
                    connection.ConnectionString = setting.ConnectionString;
                    connection.Open();

                    var users = connection.Find<User>(statement => statement.Where($"{nameof(User.UserId):C}='{userId}' AND '{now.Date}' < {nameof(User.ExpirationDate):C}"));
                    results = (users == null) ? new User() : users.First();
                }
                catch (Exception ex)
                {
                    log.Write(ex.ToString(), LevelEnum.ERRROR, setting.LogFolderPath);
                }
            }
            return results;
        }

        /// <summary>
        /// 検査情報すべて取得
        /// </summary>
        /// <returns></returns>
        public static List<OrderView> GetOrders(Setting.Setting setting)
        {
            var log = new Lib.Log.Log();
            var results = new List<OrderView>();

            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                try
                {
                    connection.ConnectionString = setting.ConnectionString;
                    connection.Open();

                    var orders = connection.Find<OrderView>();
                    results = (orders == null) ? new List<OrderView>() : orders.ToList();
                }
                catch (Exception ex)
                {
                    log.Write(ex.ToString(), LevelEnum.ERRROR, setting.LogFolderPath);
                }
            }
            return results;
        }

        /// <summary>
        /// すでに登録済みのOrderかどうか
        /// true:登録済み　false:未登録
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static bool HasOrderNo(Order order, Setting.Setting setting)
        {
            var log = new Lib.Log.Log();
            var result = false;

            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                try
                {
                    connection.ConnectionString = setting.ConnectionString;
                    connection.Open();

                    var orders = connection.Get(order);
                    result = (orders == null) ? false : true;
                }
                catch (Exception ex)
                {
                    log.Write(ex.ToString(), LevelEnum.ERRROR, setting.LogFolderPath);
                }
            }
            return result;
        }

        /// <summary>
        /// 新規登録
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static bool InsertOrder(Import.Template template, Setting.Setting setting)
        {
            var log = new Lib.Log.Log();
            var result = false;

            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                try
                {
                    connection.ConnectionString = setting.ConnectionString;
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
                    log.Write(ex.ToString(), LevelEnum.ERRROR, setting.LogFolderPath);
                }
            }
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static bool UpdateOrder(Import.Template order, Setting.Setting setting)
        {
            var log = new Lib.Log.Log();
            var result = false;

            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                try
                {
                    connection.ConnectionString = setting.ConnectionString;
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
                    log.Write(ex.ToString(), LevelEnum.ERRROR, setting.LogFolderPath);
                }
            }
            return result;
        }
    }
}
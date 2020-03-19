using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperTestDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DapperTestDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private string _connectionString;

        public UserController(IConfiguration cfg)
        {
            _connectionString = cfg["MysqlConnectionString"];
        }

        public MySqlConnection Connection
        {
            get
            {
                return new MySqlConnection(_connectionString);
            }
        }


        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("addUser")]
        public ActionResult<object> AddUser()
        {
            using (MySqlConnection connection = Connection)
            {
                string sql = "insert into users (name, email, address) values (@Name, @Email, @Address)";
                //var result = connection.Execute(sql, new { Name = "jack", Email = "467145715@qq.com", Address = "厦门" });

                var result = connection.Execute(sql, new User{ Name = "jack2", Email = "467145715@qq.com", Address = "厦门" });

                return result;
            }
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("addUsers")]
        public ActionResult<object> AddUsers()
        {
            using (MySqlConnection connection = Connection)
            {
                string sql = "insert into users (name, email, address) values (@Name, @Email, @Address)";


                var result = connection.Execute(sql, 
                    new List<User>() 
                    { 
                        new User{ Name = "aa", Email = "467145715@qq.com", Address = "龙岩" },
                        new User{ Name = "bb", Email = "482489547@qq.com", Address = "龙岩" },
                        new User{ Name = "cc", Email = "687159427@qq.com", Address = "龙岩" }
                    });

                return result;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("deleteUser")]
        public ActionResult<object> DeleteUser()
        {
            using (MySqlConnection connection = Connection)
            {
                string sql = "delete from users where id = @Id";

                var result = connection.Execute(sql, new User { Id = 6 });

                return result;
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("updateUser")]
        public ActionResult<object> UpdateUser()
        {
            using (MySqlConnection connection = Connection)
            {
                string sql = "update users set name = @Name where id = @Id";

                var result = connection.Execute(sql, new User { Id = 5, Name = "ppp" });

                return result;
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUser")]
        public ActionResult<object> GetUser()
        {
            using (MySqlConnection connection = Connection)
            {
                string sql = "select * from users";

                var result = connection.Query<User>(sql);

                return result.ToList();
            }
        }

        /// <summary>
        /// 指定条件查询数据  where
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUsers")]
        public ActionResult<object> GetUsers()
        {
            using (MySqlConnection connection = Connection)
            {
                string sql = "select * from users where address = @Address";

                var result = connection.Query<User>(sql, new { Address = "龙岩"});

                return result.ToList();
            }
        }

        /// <summary>
        /// 指定条件查询数据  in
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUsersIn")]
        public ActionResult<object> GetUsersIn()
        {
            using (MySqlConnection connection = Connection)
            {
                string sql = "select * from users where name in @Names";

                //查询姓名为tony和aa的user
                var result = connection.Query<User>(sql, 
                    new { 
                        Names = new string[2] { 
                            "tony", 
                            "aa" 
                        } 
                    });

                return result.ToList();
            }
        }

        /// <summary>
        /// 多表查询  join
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUsersJoin")]
        public ActionResult<object> GetUsersjoin()
        {
            using (MySqlConnection connection = Connection)
            {
                string sql = @"select a.id as user_id, 
                                      a.name as user_name, 
                                      a.email as user_email, 
                                      a.address as user_address, 
                                      b.id as project_id, 
                                      b.name as project_name
                               from users as a
                               join project as b
                               on a.id = b.user_id
                               where a.name = 'jack'";

                var result = connection.Query<UserProjectDTO>(sql);

                return result.ToList();
            }
        }
    }
}
using Dapper;
using DapperTestDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTestDemo.DapperHelper
{
    public class ColumnMapper
    {
        public static void SetMapper()
        {
            //数据库字段名和c#属性名不一致，手动添加映射关系
            //每个需要用到[colmun(Name="")]特性的model，都要在这里添加映射
            SqlMapper.SetTypeMap(typeof(User), new ColumnAttributeTypeMapper<User>());
            SqlMapper.SetTypeMap(typeof(UserProjectDTO), new ColumnAttributeTypeMapper<UserProjectDTO>());
        }
    }
}

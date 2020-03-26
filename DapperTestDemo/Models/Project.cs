using DapperTestDemo.DapperHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTestDemo.Models
{
    public class Project
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "user_id")]
        public int UserId { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

    }
}

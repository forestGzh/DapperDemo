using DapperTestDemo.DapperHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTestDemo.Models
{
    public class UserProjectDTO
    {
        [Column(Name = "user_id")]
        public int UserId { get; set; }

        [Column(Name = "project_id")]
        public int ProjectId { get; set; }

        [Column(Name = "user_name")]
        public string UserName { get; set; }

        [Column(Name = "project_name")]
        public string ProjectName { get; set; }

        [Column(Name = "user_email")]
        public string UserEmail { get; set; }

        [Column(Name = "user_address")]
        public string UserAddress { get; set; }
    }
}

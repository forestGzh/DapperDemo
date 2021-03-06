﻿using DapperTestDemo.DapperHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTestDemo.Models
{
    public class User
    {

        public User()
        {
            this.Projects = new List<Project>();
        }

        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        public List<Project> Projects { get; set; }
    }
}

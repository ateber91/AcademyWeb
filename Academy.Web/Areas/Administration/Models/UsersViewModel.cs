﻿using Academy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Web.Areas.Administration.Models
{
    public class UsersViewModel
    {
        public UsersViewModel(User user)
        {
            this.FullName = user.FullName;
        }

        public string FullName { get; set; }       
    }
}
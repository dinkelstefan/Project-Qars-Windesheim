﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qars.Models.DBObjects
{
    public class User
    {
        public int UserID { get; set; }
        public int accountLevel { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string postalcode { get; set; }
        public string city { get; set; }
        public string streetname { get; set; }
        public int streetnumber { get; set; }
        public string streetnumbersuffix { get; set; }
        public string phonenumber { get; set; }
        public string emailaddress { get; set; }
        public string driverslicenselink { get; set; }
        public int Establishment { get; set; }


        public User()
        {
        }
    }
}
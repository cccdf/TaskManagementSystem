using System;
using System.Collections.Generic;
using System.Text;

namespace Dingfang.TaskManagementSystem.Core.Models.Request
{
    public class UserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Mobileno { get; set; }
    }
}

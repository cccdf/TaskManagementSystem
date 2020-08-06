using System;
using System.Collections.Generic;
using System.Text;

namespace Dingfang.TaskManagementSystem.Core.Models.Response
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Mobileno { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dingfang.TaskManagementSystem.Core.Models.Request
{
    public class TaskRequestModel
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public char? Priority { get; set; }
        public string Remarks { get; set; }
    }
}

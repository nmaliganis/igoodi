using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Tasks.Models;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks
{

    public class TaskDto
    {
      public TaskDto()
      {
        this.Items = new List<Item>();
      }
        public long TotalItems { get; set; }
        public long TotalPages { get; set; }
        public List<Item> Items { get; set; }
    }
}

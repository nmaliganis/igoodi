using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Tasks.Models;

namespace igoodi.receiver360.webui.Models.DTOs.Tasks
{

    public class TaskItemDto
    {
      public long Id { get; set; }
      public string Voucher { get; set; }
      public string Type { get; set; }
    }
}

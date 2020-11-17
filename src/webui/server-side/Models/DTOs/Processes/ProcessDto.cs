using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Tasks.Models;

namespace igoodi.receiver360.webui.Models.DTOs.Processes
{

    public class ProcessDto
    {
      public string Step { get; set; }
      public string Path { get; set; }
      public string Name { get; set; }
      public int Process { get; set; }
    }
}

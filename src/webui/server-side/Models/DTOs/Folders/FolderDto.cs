using System;

namespace igoodi.receiver360.webui.Models.DTOs.Folders
{

    public class FolderDto
    {
      public string Name { get; set; }
      public string Type { get; set; }
      public bool IsFailed { get; set; }
      public DateTime DateCreated { get; set; }
    }
}

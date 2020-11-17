using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace igoodi.receiver360.api.Helpers
{
  public static class FormFileHelper
  {
        public static bool IsImage(IFormFile file)
    {
      if (file.ContentType.Contains("image"))
      {
        return true;
      }

      string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

      return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
    }
  }
}

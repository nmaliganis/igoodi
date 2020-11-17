using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Processes;

namespace igoodi.receiver360.webui.Store.Process.Actions.DeleteProcess
{
  public class DeleteProcessAction
  {
    public string Name { get; }
    public ProcessStep Step { get; }

    public DeleteProcessAction(string name, ProcessStep step)
    {
      Name = name;
      Step = step;
    }
  }
}
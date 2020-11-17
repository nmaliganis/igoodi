using igoodi.receiver360.webui.Models.DTOs.Processes;

namespace igoodi.receiver360.webui.Store.Process.Actions.CreateProcess
{
  public class CreateProcessSuccessAction
  {
    public ProcessDto Process { get; private set; }

    public CreateProcessSuccessAction(ProcessDto process)
    {
      Process = process;
    }
  }
}
using igoodi.receiver360.webui.Models.DTOs.Processes;

namespace igoodi.receiver360.webui.Store.Process.Actions.DeleteProcess
{
  public class DeleteProcessSuccessAction
  {
    public string Name { get; }

    public DeleteProcessSuccessAction(string name)
    {
      Name = name;
    }
  }
}
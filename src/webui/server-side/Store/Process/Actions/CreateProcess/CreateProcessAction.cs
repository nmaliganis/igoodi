using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Processes;

namespace igoodi.receiver360.webui.Store.Process.Actions.CreateProcess
{
  public class CreateProcessAction
  {
    public string Name { get; private set; }
    public ProcessStep Step { get; }
    public int CurrentProcess { get; }
    public List<ProcessDto> ProcessList { get; }

    public CreateProcessAction(string name, ProcessStep step, int currentProcess, List<ProcessDto> processList)
    {
      Name = name;
      Step = step;
      CurrentProcess = currentProcess;
      ProcessList = processList;
    }
  }
}
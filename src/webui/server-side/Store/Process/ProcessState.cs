using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Processes;

namespace igoodi.receiver360.webui.Store.Process
{
  public class ProcessState
  {
    public bool IsLoading { get; private set; }
    public int LastProcess { get; private set; }
    public int MaxProcess { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<ProcessDto> ProcessList { get; private set; }

    public ProcessState(
      List<ProcessDto> processList,
      int lastProcess, 
      string errorMessage, 
      bool isLoading, int maxProcess)
    {
      ProcessList = processList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      MaxProcess = maxProcess;
      LastProcess = lastProcess;
    }
  }
}
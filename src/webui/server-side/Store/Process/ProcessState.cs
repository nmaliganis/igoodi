using System.Collections.Generic;
using igoodi.receiver360.webui.Models.DTOs.Processes;

namespace igoodi.receiver360.webui.Store.Process
{
  public class ProcessState
  {
    public bool IsLoading { get; private set; }
    public int CrRecoLastProcess { get; private set; }
    public int CrRecoMaxProcess { get; private set; }
    public int CrTextLastProcess { get; private set; }
    public int CrTextMaxProcess { get; private set; }
    public int MayaLastProcess { get; private set; }
    public int MayaMaxProcess { get; private set; }
    public int UnityLastProcess { get; private set; }
    public int UnityMaxProcess { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<ProcessDto> ProcessList { get; private set; }

    public ProcessState(
      List<ProcessDto> processList,
      string errorMessage, 
      bool isLoading, 
      int crRecoLastProcess, 
      int crRecoMaxProcess,
      int crTextLastProcess, 
      int crTextMaxProcess,
      int mayaLastProcess, 
      int mayaMaxProcess,
      int unityLastProcess, 
      int unityMaxProcess
      )
    {
      ProcessList = processList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      CrRecoLastProcess = crRecoLastProcess;
      CrRecoMaxProcess = crRecoMaxProcess;
      CrTextLastProcess = crTextLastProcess;
      CrTextMaxProcess = crTextMaxProcess;
      MayaLastProcess = mayaLastProcess;
      MayaMaxProcess = mayaMaxProcess;
      UnityLastProcess = unityLastProcess;
      UnityMaxProcess = unityMaxProcess;
    }
  }
}
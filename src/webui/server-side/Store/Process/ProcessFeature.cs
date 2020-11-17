using System.Collections.Generic;
using Fluxor;
using igoodi.receiver360.webui.Models.DTOs.Processes;

namespace igoodi.receiver360.webui.Store.Process
{
  public class ProcessFeature : Feature<ProcessState>
  {
    public override string GetName() => "Process";

    protected override ProcessState GetInitialState() => new ProcessState(
      new List<ProcessDto>(), 
      1,
      "",
      true,
      2
      );
  }
}
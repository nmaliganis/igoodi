using System;
using System.Collections.Generic;
using Fluxor;
using igoodi.receiver360.webui.Models.DTOs.Processes;
using Microsoft.Extensions.Configuration;

namespace igoodi.receiver360.webui.Store.Process
{
  public class ProcessFeature : Feature<ProcessState>
  {
    public override string GetName() => "Process";

    protected override ProcessState GetInitialState() => new ProcessState(
      new List<ProcessDto>(),
      "",
      true,
      1,
      0,
      1,
      0,
      1,
      0,
      1,
      0
    );
  }
}
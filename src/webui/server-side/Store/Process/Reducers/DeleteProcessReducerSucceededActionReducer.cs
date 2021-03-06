﻿using System.Linq;
using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.DeleteProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class DeleteProcessReducerSucceededActionReducer : Reducer<ProcessState, DeleteProcessSuccessAction>
  {
    public override ProcessState Reduce(ProcessState state, DeleteProcessSuccessAction action)
    {
      var newProcessList = state.ProcessList;

      var processToBeRemoved = newProcessList.FirstOrDefault(x => x.Name == action.Name);
      newProcessList.Remove(processToBeRemoved);

      return new ProcessState(
        newProcessList,
        state.ErrorMessage,
        state.IsLoading,
        state.CrRecoLastProcess,
        state.CrRecoMaxProcess,
        state.CrTextLastProcess,
        state.CrTextMaxProcess,
        state.MayaLastProcess,
        state.MayaMaxProcess,
        state.UnityLastProcess,
        state.UnityMaxProcess
      );
    }
  }
}
﻿using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class CreateProcessReducerSucceededActionReducer : Reducer<ProcessState, CreateProcessSuccessAction>
  {
    public override ProcessState Reduce(ProcessState state, CreateProcessSuccessAction action)
    {
      var newProcessList = state.ProcessList;
      newProcessList.Add(action.Process);
      //int newLastProcess = 0;

      //if (state.LastProcess < state.MaxProcess)
      //{
      //  newLastProcess = state.LastProcess + 1;
      //}
      //else
      //{
      //  newLastProcess = 1;
      //}
      //Todo
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
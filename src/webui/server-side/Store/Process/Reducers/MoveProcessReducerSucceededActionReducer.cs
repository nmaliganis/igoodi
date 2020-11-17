﻿using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;
using igoodi.receiver360.webui.Store.Process.Actions.MoveProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class MoveProcessReducerSucceededActionReducer : Reducer<ProcessState, MoveProcessSuccessAction>
  {
    public override ProcessState Reduce(ProcessState state, MoveProcessSuccessAction action)
    {
      return new ProcessState(
        state.ProcessList,
        state.LastProcess,
        state.ErrorMessage,
        state.IsLoading,
        state.MaxProcess
      );
    }
  }
}
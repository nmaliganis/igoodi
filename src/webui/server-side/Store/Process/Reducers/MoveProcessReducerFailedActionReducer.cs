using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.MoveProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class MoveProcessReducerFailedActionReducer : Reducer<ProcessState, MoveProcessFailedAction>
  {
    public override ProcessState Reduce(ProcessState state, MoveProcessFailedAction action)
    {
      return new ProcessState(
        state.ProcessList,
        state.LastProcess,
        action.ErrorMessage,
        state.IsLoading,
        state.MaxProcess
      );
    }
  }
}
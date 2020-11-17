using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class CreateProcessReducerFailedActionReducer : Reducer<ProcessState, CreateProcessFailedAction>
  {
    public override ProcessState Reduce(ProcessState state, CreateProcessFailedAction action)
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
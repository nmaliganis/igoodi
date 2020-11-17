using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class CreateProcessReducerSucceededActionReducer : Reducer<ProcessState, CreateProcessSuccessAction>
  {
    public override ProcessState Reduce(ProcessState state, CreateProcessSuccessAction action)
    {
      var newProcessList = state.ProcessList;
      newProcessList.Add(action.Process);
      int newLastProcess = 0;

      if (state.LastProcess < state.MaxProcess)
      {
        newLastProcess = state.LastProcess + 1;
      }
      else
      {
        newLastProcess = 1;
      }

      return new ProcessState(
        newProcessList,
        newLastProcess,
        state.ErrorMessage,
        state.IsLoading,
        state.MaxProcess
      );
    }
  }
}
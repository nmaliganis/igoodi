using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class RetexturingSucceededActionReducer : Reducer<ProcessState, RetexturingSuccessAction>
  {
    public override ProcessState Reduce(ProcessState state, RetexturingSuccessAction action)
    {
      var newProcessList = state.ProcessList;
      if(action.Process != null)
        newProcessList.Add(action.Process);

      int newLastProcess = 0;

      if (state.CrTextLastProcess < action.RetexturingMax)
      {
        newLastProcess = state.CrTextLastProcess + 1;
      }
      else
      {
        newLastProcess = 1;
      }

      //Todo
      return new ProcessState(
        newProcessList,
        state.ErrorMessage,
        state.IsLoading,
        state.CrRecoLastProcess,
        state.CrRecoMaxProcess,
        newLastProcess,
        action.RetexturingMax,
        state.MayaLastProcess,
        state.MayaMaxProcess,
        state.UnityLastProcess,
        state.UnityMaxProcess
      );
    }
  }
}
using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class MayaSucceededActionReducer : Reducer<ProcessState, MayaSuccessAction>
  {
    public override ProcessState Reduce(ProcessState state, MayaSuccessAction action)
    {
      var newProcessList = state.ProcessList;
      newProcessList.Add(action.Process);

      int newLastProcess = 0;

      if (state.CrTextLastProcess < action.MayaMax)
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
        state.CrTextLastProcess,
        state.CrTextMaxProcess,
        newLastProcess,
        action.MayaMax,
        state.UnityLastProcess,
        state.UnityMaxProcess
      );
    }
  }
}
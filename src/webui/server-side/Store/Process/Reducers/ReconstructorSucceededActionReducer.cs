using Fluxor;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;

namespace igoodi.receiver360.webui.Store.Process.Reducers
{
  public class ReconstructorSucceededActionReducer : Reducer<ProcessState, ReconstructionSuccessAction>
  {
    public override ProcessState Reduce(ProcessState state, ReconstructionSuccessAction action)
    {
      var newProcessList = state.ProcessList;
      if(action.Process != null)
        newProcessList.Add(action.Process);

      int newLastProcess = 0;

      if (state.CrRecoLastProcess < action.ReconstructionMax)
      {
        newLastProcess = state.CrRecoLastProcess + 1;
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
        newLastProcess,
        action.ReconstructionMax,
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
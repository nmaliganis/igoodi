using Fluxor;
using igoodi.receiver360.webui.Store.Tasks.Actions.FetchTask;

namespace igoodi.receiver360.webui.Store.Tasks.Reducers.FetchTask
{
  public class FetchTaskReducerFailedActionReducer : Reducer<TaskState, FetchTaskFailedAction>
  {
    public override TaskState Reduce(TaskState state, FetchTaskFailedAction action)
    {
      return new TaskState(
        state.TaskList,
        action.ErrorMessage,
        state.IsLoading,
        state.Task
      );
    }
  }
}
using Fluxor;
using igoodi.receiver360.webui.Store.Tasks.Actions.FetchTask;

namespace igoodi.receiver360.webui.Store.Tasks.Reducers.FetchTask
{
  public class FetchTaskReducerSuccessActionReducer : Reducer<TaskState, FetchTaskSuccessAction>
  {
    public override TaskState Reduce(TaskState state, FetchTaskSuccessAction action)
    {
      return new TaskState(
        state.TaskList,
        "",
        state.IsLoading,
        action.Task
        );
    }
  }
}
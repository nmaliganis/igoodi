using Fluxor;
using igoodi.receiver360.webui.Store.Tasks.Actions.FetchTask;

namespace igoodi.receiver360.webui.Store.Tasks.Reducers.FetchTask
{
  public class FetchTaskReducer : Reducer<TaskState, FetchTaskAction>
  {
    public override TaskState Reduce(TaskState state, FetchTaskAction action)
    {
      return new TaskState(
        state.TaskList,
        "",
        state.IsLoading,
        state.Task
        );
    }
  }
}
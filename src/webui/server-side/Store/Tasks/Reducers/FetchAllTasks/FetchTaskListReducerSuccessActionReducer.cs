using Fluxor;
using igoodi.receiver360.webui.Store.Tasks.Actions.FetchAllTasks;

namespace igoodi.receiver360.webui.Store.Tasks.Reducers.FetchAllTasks
{
  public class FetchTaskListReducerSuccessActionReducer : Reducer<TaskState, FetchTaskListSuccessAction>
  {
    public override TaskState Reduce(TaskState state, FetchTaskListSuccessAction action)
    {
      return new TaskState(
        action.TaskList,
        "",
        state.IsLoading,
        state.Task
      );
    }
  }
}
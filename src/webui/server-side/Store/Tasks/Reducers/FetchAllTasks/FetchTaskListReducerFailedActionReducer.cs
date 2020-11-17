using Fluxor;
using igoodi.receiver360.webui.Store.Tasks.Actions.FetchAllTasks;

namespace igoodi.receiver360.webui.Store.Tasks.Reducers.FetchAllTasks
{
  public class FetchTaskListReducerFailedActionReducer : Reducer<TaskState, FetchTaskListFailedAction>
  {
    public override TaskState Reduce(TaskState state, FetchTaskListFailedAction action)
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
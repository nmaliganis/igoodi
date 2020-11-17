using Fluxor;
using igoodi.receiver360.webui.Store.Tasks.Actions.FetchAllTasks;

namespace igoodi.receiver360.webui.Store.Tasks.Reducers.FetchAllTasks
{
  public class FetchTaskListReducer : Reducer<TaskState, FetchTaskListAction>
  {
    public override TaskState Reduce(TaskState state, FetchTaskListAction action)
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
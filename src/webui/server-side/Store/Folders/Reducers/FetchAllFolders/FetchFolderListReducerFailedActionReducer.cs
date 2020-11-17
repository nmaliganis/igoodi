using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchAllFolders
{
  public class FetchFolderListReducerFailedActionReducer : Reducer<FolderState, FetchFolderListFailedAction>
  {
    public override FolderState Reduce(FolderState state, FetchFolderListFailedAction action)
    {
      return new FolderState(
        state.FolderList,
        state.FailedFolderList,
        state.ReconstructionFolderList,
        state.RetexturingFolderList,
        action.ErrorMessage,
        state.IsLoading,
        state.Folder
        );
    }
  }
}
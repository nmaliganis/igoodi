using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchAllFolders
{
  public class FetchFailedFolderListReducerSuccessActionReducer : Reducer<FolderState, FetchFailedFolderListSuccessAction>
  {
    public override FolderState Reduce(FolderState state, FetchFailedFolderListSuccessAction action)
    {
      return new FolderState(
        state.FolderList,
        action.FolderList,
        state.ReconstructionFolderList,
        state.RetexturingFolderList,
        "",
        state.IsLoading,
        state.Folder
      );
    }
  }
}
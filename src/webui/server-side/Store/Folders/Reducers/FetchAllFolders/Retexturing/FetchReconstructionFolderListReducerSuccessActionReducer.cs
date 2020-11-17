using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchAllFolders.Retexturing
{
  public class FetchRetexturingFolderListReducerSuccessActionReducer : Reducer<FolderState, FetchRetexturingFolderListSuccessAction>
  {
    public override FolderState Reduce(FolderState state, FetchRetexturingFolderListSuccessAction action)
    {
      return new FolderState(
        state.FolderList,
        state.FailedFolderList,
        state.ReconstructionFolderList,
        action.FolderList,
        "",
        state.IsLoading,
        state.Folder
      );
    }
  }
}
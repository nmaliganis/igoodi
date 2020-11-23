using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Maya;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchAllFolders.Maya
{
  public class FetchMayaFolderListReducerSuccessActionReducer : Reducer<FolderState, FetchMayaFolderListSuccessAction>
  {
    public override FolderState Reduce(FolderState state, FetchMayaFolderListSuccessAction action)
    {
      return new FolderState(
        state.FolderList,
        state.FailedFolderList,
        state.ReconstructionFolderList,
        state.RetexturingFolderList,
        action.FolderList,
        state.UnityFolderList,
        "",
        state.IsLoading,
        state.Folder
      );
    }
  }
}
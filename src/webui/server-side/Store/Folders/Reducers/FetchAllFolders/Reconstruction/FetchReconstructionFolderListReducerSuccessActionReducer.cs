using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Reconstruction;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchAllFolders.Reconstruction
{
  public class FetchReconstructionFolderListReducerSuccessActionReducer : Reducer<FolderState, FetchReconstructionFolderListSuccessAction>
  {
    public override FolderState Reduce(FolderState state, FetchReconstructionFolderListSuccessAction action)
    {
      return new FolderState(
        state.FolderList,
        state.FailedFolderList,
        action.FolderList,
        state.RetexturingFolderList,
        state.MayaFolderList,
        state.UnityFolderList,
        "",
        state.IsLoading,
        state.Folder
      );
    }
  }
}
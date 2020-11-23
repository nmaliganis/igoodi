using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Unity;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchAllFolders.Unity
{
  public class FetchUnityFolderListReducerSuccessActionReducer : Reducer<FolderState, FetchUnityFolderListSuccessAction>
  {
    public override FolderState Reduce(FolderState state, FetchUnityFolderListSuccessAction action)
    {
      return new FolderState(
        state.FolderList,
        state.FailedFolderList,
        state.ReconstructionFolderList,
        state.RetexturingFolderList,
        state.MayaFolderList,
        action.FolderList,
        "",
        state.IsLoading,
        state.Folder
      );
    }
  }
}
using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchFolder;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchFolder
{
  public class FetchFolderReducer : Reducer<FolderState, FetchFolderAction>
  {
    public override FolderState Reduce(FolderState state, FetchFolderAction action)
    {
      return new FolderState(
        state.FolderList,
        state.FailedFolderList,
        state.ReconstructionFolderList,
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
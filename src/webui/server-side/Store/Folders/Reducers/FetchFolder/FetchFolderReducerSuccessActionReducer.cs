using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchFolder;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchFolder
{
  public class FetchFolderReducerSuccessActionReducer : Reducer<FolderState, FetchFolderSuccessAction>
  {
    public override FolderState Reduce(FolderState state, FetchFolderSuccessAction action)
    {
      return new FolderState(
        state.FolderList,
        state.FailedFolderList,
        state.ReconstructionFolderList,
        state.RetexturingFolderList,
        "",
        state.IsLoading,
        action.Folder
        );
    }
  }
}
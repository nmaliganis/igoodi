using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchFolder;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchFolder
{
  public class FetchFolderReducerFailedActionReducer : Reducer<FolderState, FetchFolderFailedAction>
  {
    public override FolderState Reduce(FolderState state, FetchFolderFailedAction action)
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
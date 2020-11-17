using Fluxor;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders;

namespace igoodi.receiver360.webui.Store.Folders.Reducers.FetchAllFolders
{
  public class FetchFolderListReducer : Reducer<FolderState, FetchFolderListAction>
  {
    public override FolderState Reduce(FolderState state, FetchFolderListAction action)
    {
      return new FolderState(
        state.FolderList,
        state.FailedFolderList,
        state.ReconstructionFolderList,
        state.RetexturingFolderList,
        "",
        state.IsLoading,
        state.Folder
      );
    }
  }
}
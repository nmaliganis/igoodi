using System;

namespace igoodi.receiver360.webui.Store.Folders.Actions.FetchFolder
{
  public class FetchFolderAction
  {
    public string Name { get; private set; }
    public FetchFolderAction(string name)
    {
      Name = name;
    }
  }
}
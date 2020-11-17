namespace igoodi.receiver360.webui.Commanding.Events.Args
{
  public class ScannedDetectionEventArgs : System.EventArgs
  {
    public string Payload { get; private set; }
    public bool Success { get; private set; }
    public string FolderName { get; private set; }

    public ScannedDetectionEventArgs(string payload, bool success, string folderName)
    {
      this.Payload = payload;
      this.Success = success;
      this.FolderName = folderName;
    }
  }
}
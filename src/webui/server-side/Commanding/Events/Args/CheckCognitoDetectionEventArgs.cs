namespace igoodi.receiver360.webui.Commanding.Events.Args
{
  public class CheckCognitoDetectionEventArgs : System.EventArgs
  {
    public string Payload { get; private set; }
    public bool Success { get; private set; }

    public CheckCognitoDetectionEventArgs(string payload, bool success)
    {
      this.Payload = payload;
      this.Success = success;
    }
  }
}
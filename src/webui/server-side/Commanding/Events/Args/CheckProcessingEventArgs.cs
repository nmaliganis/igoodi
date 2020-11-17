namespace igoodi.receiver360.webui.Commanding.Events.Args
{
  public class CheckProcessingEventArgs : System.EventArgs
  {
    public int Process { get; private set; }
    public string Payload { get; private set; }
    public bool Success { get; private set; }

    public CheckProcessingEventArgs(string payload, bool success, int process)
    {
      this.Payload = payload;
      this.Success = success;
      this.Process = process;
    }
  }
}
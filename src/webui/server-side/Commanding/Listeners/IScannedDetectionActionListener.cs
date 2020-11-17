using igoodi.receiver360.webui.Commanding.Events.Args;

namespace igoodi.receiver360.webui.Commanding.Listeners
{
  public interface IScannedDetectionActionListener
  {
    void Update(object sender, ScannedDetectionEventArgs e);
  }
}
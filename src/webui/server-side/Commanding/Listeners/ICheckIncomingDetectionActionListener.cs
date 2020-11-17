using igoodi.receiver360.webui.Commanding.Events.Args;

namespace igoodi.receiver360.webui.Commanding.Listeners
{
  public interface ICheckIncomingDetectionActionListener
  {
    void Update(object sender, CheckIncomingDetectionEventArgs e);
  }
}
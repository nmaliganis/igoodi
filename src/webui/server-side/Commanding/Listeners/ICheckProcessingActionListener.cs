using igoodi.receiver360.webui.Commanding.Events.Args;

namespace igoodi.receiver360.webui.Commanding.Listeners
{
  public interface ICheckProcessingActionListener
  {
    void Update(object sender, CheckProcessingEventArgs e);
  }
}
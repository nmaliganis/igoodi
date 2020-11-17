using igoodi.receiver360.webui.Commanding.Events.Args;

namespace igoodi.receiver360.webui.Commanding.Listeners
{
  public interface ICheckFailureProcessingActionListener
  {
    void Update(object sender, CheckFailureProcessingEventArgs e);
  }
}
using igoodi.receiver360.webui.Commanding.Events.Args;

namespace igoodi.receiver360.webui.Commanding.Listeners
{
  public interface ICheckCognitoDetectionActionListener
  {
    void Update(object sender, CheckCognitoDetectionEventArgs e);
  }
}
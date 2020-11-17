using System.Threading.Tasks;

namespace igoodi.receiver360.webui.Slack
{
  public interface ISlackMessageSender
  {
    Task SendMessageOnRandomAsync(string text);
  }
}
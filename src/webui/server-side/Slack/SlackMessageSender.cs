using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace igoodi.receiver360.webui.Slack
{
  public class SlackMessageSender : ISlackMessageSender
  {
    private readonly HttpClient _client;

    private const string Igoodi360ReceiverChannel = "/services/TP7AX8DPZ/B01D2UY8YA2/yLefRSRqQcCGuua7cVb3tld7";

    public SlackMessageSender(HttpClient client)
    {
      _client = client;
    }

    public async Task SendMessageOnRandomAsync(string text)
    {
      var contentObject = new { text = text };
      var contentObjectJson = JsonSerializer.Serialize(contentObject);
      var content = new StringContent(contentObjectJson, Encoding.UTF8, "application/json");

      var result = await _client.PostAsync(Igoodi360ReceiverChannel, content);
      var resultContent = await result.Content.ReadAsStringAsync();
      if (!result.IsSuccessStatusCode)
      {
        throw new Exception("Task failed.");
      }
    }
  }
}
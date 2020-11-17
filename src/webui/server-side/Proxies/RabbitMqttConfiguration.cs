using System;
using System.Text;
using igoodi.receiver360.webui.Commanding.Events.Args;
using igoodi.receiver360.webui.Commanding.Listeners;
using igoodi.receiver360.webui.Commanding.Servers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace igoodi.receiver360.webui.Proxies
{
  public class RabbitMqttConfiguration : IRabbitMqttConfiguration, IScannedDetectionActionListener
  {
    public IConfiguration Configuration { get; }
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IServiceProvider _service;

    private MqttClient _client;

    public RabbitMqttConfiguration(IConfiguration configuration, 
      IServiceScopeFactory scopeFactory, IServiceProvider service)
    {
      Configuration = configuration;
      _scopeFactory = scopeFactory;
      _service = service;

      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((IScannedDetectionActionListener) this);
    }

    public void EstablishConnection()
    {
      _client = new MqttClient(Configuration.GetSection("RabbitMq:Api").Value);

      _client.Subscribe(new[]
        {
          "scanned/ack"
        },
        new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });  
      
      _client.Subscribe(new[]
        {
          "scanned/nack"
        },
        new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });  

      _client.Subscribe(new[]
        {
          "scanned/message"
        },
        new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
      
      _client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;
      _client.ConnectionClosed += ClientConnectionClosed;
      _client.MqttMsgPublished += ClientMqttMsgPublished;
      _client.MqttMsgSubscribed += ClientMqttMsgSubscribed;
      _client.MqttMsgUnsubscribed += ClientMqttMsgUnsubscribed;

      _client.Connect($"IGOODI-{Guid.NewGuid().ToString()}",
        Configuration.GetSection("RabbitMq:Username").Value
        ,Configuration.GetSection("RabbitMq:Password").Value
      );
    }

    private void ClientMqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
    {
    }

    private void ClientMqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
    {
    }

    private void ClientMqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
    {
    }

    private void ClientConnectionClosed(object sender, EventArgs e)
    {
    }

    private void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {

    }


    public void Update(object sender, ScannedDetectionEventArgs e)
    {
      if (_client.IsConnected)
      {
        //Todo: Log for Mqtt
        var result = _client.Publish(Configuration.GetSection("MqttTopics:Scanned").Value, Encoding.UTF8.GetBytes(e.Payload));
      }
    }
  }
}
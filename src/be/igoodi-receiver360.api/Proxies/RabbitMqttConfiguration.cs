using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace igoodi.receiver360.api.Proxies
{
  public class RabbitMqttConfiguration : IRabbitMqttConfiguration
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
    }

    public void EstablishConnection()
    {
      _client = new MqttClient(Configuration.GetSection("RabbitMq:Api").Value);

      _client.Subscribe(new[]
        {
          "wm/ack"
        },
        new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

      _client.Subscribe(new[]
        {
          "mb/nack"
        },
        new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

      _client.Subscribe(new[]
        {
          "mb/telemetry/message"
        },
        new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

      _client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;
      _client.ConnectionClosed += ClientConnectionClosed;
      _client.MqttMsgPublished += ClientMqttMsgPublished;
      _client.MqttMsgSubscribed += ClientMqttMsgSubscribed;
      _client.MqttMsgUnsubscribed += ClientMqttMsgUnsubscribed;

      _client.Connect($"CMS-MB-{Guid.NewGuid().ToString()}",
        Configuration.GetSection("RabbitMq:Username").Value
        , Configuration.GetSection("RabbitMq:Password").Value
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

    private async void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
      var jsonToBeSerialized = System.Text.Encoding.Default.GetString(e.Message);
      //TelemetryMessageModel telemetryModelModel = JsonConvert.DeserializeObject<TelemetryMessageModel>(jsonToBeSerialized);
      //try
      //{
      //  await DoScopedMeasurementStore(jsonToBeSerialized, telemetryModelModel);
      //}
      //catch (Exception exception)
      //{
      //  //Todo: Handle Exception
      //}
    }

    //private async Task DoScopedMeasurementStore(string jsonValue, TelemetryMessageModel telemetryModelModel)
    //{
    //  using var scope = _scopeFactory.CreateScope();
    //  //var iUpdateDeviceProcessor = scope.ServiceProvider.GetRequiredService<IUpdateDeviceProcessor>();
    //  //await iUpdateDeviceProcessor.StoreMeasurement(telemetryModelModel.deviceid, jsonValue, new DeviceForNotificationModel()
    //  //{
    //  //  MeasurementValueJson = jsonValue,
    //  //  DeviceId = telemetryModelModel.deviceid,
    //  //  CorrelationId = telemetryModelModel.correlationId,
    //  //  Timestamp = telemetryModelModel.timestamp,
    //  //  ButtonStatus = telemetryModelModel.buttonStatus,
    //  //  BatValue = telemetryModelModel.batValue,
    //  //  TempValue = telemetryModelModel.tempValue,
    //  //  Rssi = telemetryModelModel.rssi,
    //  //  Snr = telemetryModelModel.snr,
    //  //});
    //}
  }
}
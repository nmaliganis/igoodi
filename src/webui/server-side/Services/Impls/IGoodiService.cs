using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using igoodi.receiver360.webui.Models.DTOs.Assets;
using igoodi.receiver360.webui.Services.Contracts;
using Microsoft.Extensions.Configuration;

namespace igoodi.receiver360.webui.Services.Impls
{

  public class IgoodiService : IIgoodiService
  {
    private readonly HttpClient _httpClient;
    public IConfiguration Configuration { get; set; }
    public string BaseAddr { get; private set; }
    public string RemoteAddr { get; private set; }
    public string Version { get; private set; }
    public IgoodiService(IConfiguration configuration, HttpClient httpClient)
    {
      Configuration = configuration;
      _httpClient = httpClient;
      OnCreated();
    }
    private void OnCreated()
    {
      RemoteAddr = Configuration["remote"];
      BaseAddr = Configuration["env"] == "prod" ? Configuration["RemoteCrnUrl"] : Configuration["LocalCrmUrl"];
      Version = Configuration["version"];
    }

    public Task<List<AssetDto>> GetAssetList()
    {
      throw new NotImplementedException();
    }
  }
}
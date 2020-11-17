using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using igoodi.receiver360.webui.Models.DTOs.Assets;

namespace igoodi.receiver360.webui.Services.Contracts
{
  public interface IIgoodiService
  {
    Task<List<AssetDto>> GetAssetList();
  }
}
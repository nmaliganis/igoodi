using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using igoodi.receiver360.common.infrastructure.cognito.users.Excepotions;
using igoodi.receiver360.common.infrastructure.cognito.users.Models;

namespace igoodi.receiver360.common.infrastructure.cognito.users.Validator
{
  public class JwtTokenObject
  {
    private readonly JwtSecurityToken _jwtToken = null;

    public JwtTokenObject(String token)
    {
      try
      {
        _jwtToken = new JwtSecurityToken(token);
        if (_jwtToken == null)
        {
          throw new TokenNotValid();
        }
      }
      catch (Exception ex)
      {
        throw new TokenNotValid(ex.Message, ex.StackTrace);
      }
    }

    public DateTime GetValidDate()
    {
      return _jwtToken.ValidTo;
    }


    public String GetPayloadItem(string key)
    {
      var item = _jwtToken.Payload[key].ToString();
      return item;
    }

    public List<PayloadItem> GetPayloads()
    {
      List<PayloadItem> items = new List<PayloadItem>();

      foreach (var payload in _jwtToken.Payload)
      {
        PayloadItem item = new PayloadItem()
        {
          Key = payload.Key,
          Value = payload.Value.ToString()
        };
        items.Add(item);
      }

      return items;
    }

    public bool IsValidDate()
    {
      var validDate = GetValidDate();
      if (validDate > DateTime.Now) return false;
      return true;
    }

    public List<PayloadItem> GetClaims()
    {
      List<PayloadItem> items = new List<PayloadItem>();

      foreach (var claim in _jwtToken.Claims)
      {
        PayloadItem item = new PayloadItem()
        {
          Key = claim.Type,
          Value = claim.Value
        };
        items.Add(item);
      }

      return items;
    }

    public Dictionary<string, string> GetProperties()
    {
      var items = new Dictionary<String, String>();
      return _jwtToken.Claims.ToDictionary(x => x.Type, x => x.Value);
    }
  }
}

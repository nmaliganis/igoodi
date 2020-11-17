using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace igoodi.receiver360.common.infrastructure.cognito.users.Models
{
  /// <summary>
  ///    Represents the result of an identity operation.
  /// </summary>
  public class ApiIdentityResult
  {
    /// <summary>
    ///  Flag indicating whether if the operation succeeded or not.
    /// </summary>
    public bool Succeeded { get; set; } = false;

    /// <summary>
    ///  Identity Token
    /// </summary>
    public Dictionary<string, string> Properties { get; private set; } = new Dictionary<string, string>();

    /// <summary>
    ///      indicating a failed identity operation, with a list of errors if applicable.
    /// </summary>
    public ApiIdentityError Failed { get; set; } = new ApiIdentityError();

    /// <summary>
    ///   Token
    /// </summary>
    /// 
    public string Token
    {
      get => _token;
      set
      {
        _token = value;
        try
        {
          if (!string.IsNullOrEmpty(value))
          {
            var jwtToken = new JwtSecurityToken(value);
            var items = new Dictionary<String, String>();
            Properties = jwtToken.Claims.ToDictionary(x => x.Type, x => x.Value);
            ValidTo = jwtToken.ValidTo;
          }
          else
          {
            ValidTo = DateTime.MinValue;
            Properties = new Dictionary<string, string>();
          }
        }
        catch (Exception)
        {
          Properties = new Dictionary<string, string>();
        }
      }
    }



    private string _token = "";

    /// <summary>
    ///     Gets the 'expiration' datetime converted to a System.DateTime,  UnixEpoch (UTC 1970-01-01T0:0:0Z). 
    /// </summary>
    public DateTime ValidTo { get; private set; }

    /// <summary>
    ///    Converts the value of the current ApiIdentityResult 
    ///     object to its equivalent string representation.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return Succeeded ? Token : $"Failed: {Failed.Code} , {Failed.Description}";
    }

    public void SetFailed(int code, string message)
    {
      Succeeded = false;
      Failed.Code = code;
      Failed.Description = message;
    }
  }
}
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using igoodi.receiver360.common.infrastructure.cognito.users;
using igoodi.receiver360.webui.Models.DTOs.Tasks;
using igoodi.receiver360.webui.Services.Base;
using igoodi.receiver360.webui.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace igoodi.receiver360.webui.Services.Impls
{
  public class TaskService : ITaskService
  {
    public IConfiguration Configuration { get; set; }
    public string RemoteAddr { get; private set; }
    public TaskService(IConfiguration configuration)
    {
      Configuration = configuration;
      OnCreated();
    }
    private void OnCreated()
    {
      RemoteAddr = Configuration["remote"];
    }

    public async Task<TaskDto> GetTaskList()
    {
      CognitoUserManager cognito = new CognitoUserManager();
      var authorizationToken = cognito.Login(Configuration["AWS:Email"], Configuration["AWS:Password"]);
      TaskDto result = new TaskDto();

      var client = new RestClient($"{RemoteAddr}/api/lazyScanProcesses?itemsPerPage=100&pageIndex=0&currentTask.automatic=true&currentTask.status=0");
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {authorizationToken}");

      var response = await client.ExecuteAsync(request);
      if (response.IsSuccessful)
      {
        result = JsonConvert.DeserializeObject<TaskDto>(response.Content);
      }
      else if (response.StatusCode == HttpStatusCode.BadRequest)
      {
        TaskErrorModel resultError = JsonConvert.DeserializeObject<TaskErrorModel>(response.Content);
        throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      }
      return result;
    }

    public async Task<TaskDto> GetTask(Guid id)
    {
      CognitoUserManager cognito = new CognitoUserManager();
      var authorizationToken = cognito.Login(Configuration["AWS.Email"], Configuration["AWS.Password"]);

      TaskDto result = new TaskDto();

      //var client = new RestClient($"{BaseAddr}/api/{Version}/Tasks/{id}");
      //var request = new RestRequest(Method.GET);

      //request.AddHeader("Content-Type", "application/json");
      //request.AddHeader("Authorization", $"bearer {authorizationToken}");

      //var response = await client.ExecuteAsync(request);
      //if (response.IsSuccessful)
      //{
      //  result = JsonConvert.DeserializeObject<TaskDto>(response.Content);
      //}
      //else if (response.StatusCode == HttpStatusCode.BadRequest)
      //{
      //  TaskErrorModel resultError = JsonConvert.DeserializeObject<TaskErrorModel>(response.Content);
      //  throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
      //}

      return result;
    }
  }
}
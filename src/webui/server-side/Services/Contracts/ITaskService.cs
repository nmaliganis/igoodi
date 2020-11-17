using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using igoodi.receiver360.webui.Models.DTOs.Tasks;

namespace igoodi.receiver360.webui.Services.Contracts
{
  public interface ITaskService
  {
    Task<TaskDto> GetTaskList();
    Task<TaskDto> GetTask(Guid actionTaskId);
  }
}
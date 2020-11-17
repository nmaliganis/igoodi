using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using igoodi.receiver360.webui.Commanding.Events.Args;
using igoodi.receiver360.webui.Commanding.Listeners;
using igoodi.receiver360.webui.Commanding.Servers;
using igoodi.receiver360.webui.Models.DTOs.Tasks;
using igoodi.receiver360.webui.Slack;
using igoodi.receiver360.webui.Store.Tasks;
using igoodi.receiver360.webui.Store.Tasks.Actions.FetchAllTasks;
using Microsoft.AspNetCore.Components;

namespace igoodi.receiver360.webui.Pages.ViewModels
{
  public class TasksViewModel : FluxorComponent, IScannedDetectionActionListener
  {
    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public IState<TaskState> TaskState { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public ISlackMessageSender SlackService { get; set; }

    #region Initialization

    public void FetchTasksWasClicked()
    {
      Dispatcher.Dispatch(new FetchTaskListAction());
    }
    protected override Task OnInitializedAsync()
    {
      Dispatcher.Dispatch(new FetchTaskListAction());
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((IScannedDetectionActionListener) this);
      StateHasChanged();
      return base.OnInitializedAsync();
    }

    public void Dispose()
    {
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Detach((IScannedDetectionActionListener) this);
      GC.SuppressFinalize(this);
    }

    #endregion
    protected void PageChangedHandler(int currentPage)
    {

    }
    public TaskItemDto SelectedTaskItem { get; set; }
    private IEnumerable<TaskItemDto> _selectedItems; 
    public IEnumerable<TaskItemDto> SelectedItems 
    {
      get
      {
        if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<TaskItemDto>()))
          return _selectedItems;

        if(TaskState.Value.TaskList == null)
          return _selectedItems = Enumerable.Empty<TaskItemDto>();
        SelectedTaskItem = TaskState.Value.TaskList.FirstOrDefault();
        return _selectedItems = new List<TaskItemDto> { SelectedTaskItem };
      }
      set => _selectedItems = value;
    }
    protected void OnSelect(IEnumerable<TaskItemDto> taskItems)
    {
      SelectedTaskItem = taskItems.FirstOrDefault();
      SelectedItems = new List<TaskItemDto> { SelectedTaskItem };
    }
    public void Update(object sender, ScannedDetectionEventArgs e)
    {
      Dispatcher.Dispatch(new FetchTaskListAction());
    }
  }
}
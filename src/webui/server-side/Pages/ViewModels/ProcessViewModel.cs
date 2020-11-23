using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using igoodi.receiver360.webui.Commanding.Events.Args;
using igoodi.receiver360.webui.Commanding.Listeners;
using igoodi.receiver360.webui.Commanding.Servers;
using igoodi.receiver360.webui.Models.DTOs.Processes;
using igoodi.receiver360.webui.Slack;
using igoodi.receiver360.webui.Store.Folders;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Maya;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Reconstruction;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Retexturing;
using igoodi.receiver360.webui.Store.Folders.Actions.FetchAllFolders.Unity;
using igoodi.receiver360.webui.Store.Process;
using igoodi.receiver360.webui.Store.Process.Actions.CreateProcess;
using igoodi.receiver360.webui.Store.Process.Actions.DeleteProcess;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace igoodi.receiver360.webui.Pages.ViewModels
{
  public class ProcessViewModel : FluxorComponent, IScannedDetectionActionListener, ICheckProcessingActionListener
  {
    [Inject] public IDispatcher Dispatcher { get; set; }
    [Inject] public IState<FolderState> FolderState { get; set; }
    [Inject] public IState<ProcessState> ProcessState { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public ISlackMessageSender SlackService { get; set; }
    [Inject] public IConfiguration Configuration { get; set; }

    #region Initialization

    protected override Task OnInitializedAsync()
    {
      Dispatcher.Dispatch(new FetchReconstructionFolderListAction());
      Dispatcher.Dispatch(new FetchRetexturingFolderListAction());
      Dispatcher.Dispatch(new FetchReconstructionFailureFolderListAction());
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((IScannedDetectionActionListener) this);
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((ICheckProcessingActionListener) this);
      StateHasChanged();
      return base.OnInitializedAsync();
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Detach((IScannedDetectionActionListener) this);
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Detach((ICheckProcessingActionListener) this);
      GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    #endregion

    protected void PageChangedHandler(int currentPage)
    {
    }

    public ProcessDto SelectedProcessItem { get; set; }
    private IEnumerable<ProcessDto> _selectedItems;

    public IEnumerable<ProcessDto> SelectedItems
    {
      get
      {
        if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<ProcessDto>()))
          return _selectedItems;

        if (ProcessState.Value.ProcessList == null)
          return _selectedItems = Enumerable.Empty<ProcessDto>();
        SelectedProcessItem = ProcessState.Value.ProcessList.FirstOrDefault();
        return _selectedItems = new List<ProcessDto> {SelectedProcessItem};
      }
      set => _selectedItems = value;
    }

    protected void OnSelect(IEnumerable<ProcessDto> processItems)
    {
      SelectedProcessItem = processItems.FirstOrDefault();
      SelectedItems = new List<ProcessDto> {SelectedProcessItem};
    }


    public void Update(object sender, ScannedDetectionEventArgs e)
    {
      Dispatcher.Dispatch(new FetchReconstructionFolderListAction());
      Dispatcher.Dispatch(new FetchRetexturingFolderListAction());
      Dispatcher.Dispatch(new FetchMayaFolderListAction());
      Dispatcher.Dispatch(new FetchUnityFolderListAction());
      Dispatcher.Dispatch(new FetchReconstructionFailureFolderListAction());

      var slackValue = Configuration.GetSection($"{Configuration["env"]}:slack")
        .Value;
      if (slackValue == "true")
        SlackService.SendMessageOnRandomAsync($"Reconstruction Scanned at:{DateTime.Now}");
    }

    public void Update(object sender, CheckProcessingEventArgs e)
    {
      List<string> reconstructions = new List<string>();
      foreach (var reconstructionFolder in FolderState.Value.ReconstructionFolderList)
      {
        Thread.Sleep(20);
        Dispatcher.Dispatch(action: new CreateProcessAction(reconstructionFolder.Name, ProcessStep.Reconstruction,
          ProcessState.Value.LastProcess, ProcessState.Value.ProcessList));
        reconstructions.Add(reconstructionFolder.Name);
      }

      foreach (var reconstruction in reconstructions)
      {
        Thread.Sleep(10);
        Dispatcher.Dispatch(new DeleteProcessAction(reconstruction, ProcessStep.Reconstruction));
      }

      List<string> retexturings = new List<string>();
      foreach (var retexturingFolderList in FolderState.Value.RetexturingFolderList)
      {
        Thread.Sleep(20);
        Dispatcher.Dispatch(action: new CreateProcessAction(retexturingFolderList.Name, ProcessStep.Retexturing,
          ProcessState.Value.LastProcess, ProcessState.Value.ProcessList));
        retexturings.Add(retexturingFolderList.Name);
      }

      foreach (var retexturing in retexturings)
      {
        Thread.Sleep(10);
        Dispatcher.Dispatch(new DeleteProcessAction(retexturing, ProcessStep.Retexturing));
      }
    }
  }
}
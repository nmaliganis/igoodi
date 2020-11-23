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
using igoodi.receiver360.webui.Models.DTOs.Folders;
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
using igoodi.receiver360.webui.Store.Process.Actions.MoveProcess;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace igoodi.receiver360.webui.Pages.ViewModels
{
  public class ReconstructionViewModel : FluxorComponent, IScannedDetectionActionListener,
    ICheckProcessingActionListener, ICheckFailureProcessingActionListener
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
      Dispatcher.Dispatch(new FetchMayaFolderListAction());
      Dispatcher.Dispatch(new FetchUnityFolderListAction());
      Dispatcher.Dispatch(new FetchReconstructionFailureFolderListAction());
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((IScannedDetectionActionListener) this);
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((ICheckProcessingActionListener) this);
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Attach((ICheckFailureProcessingActionListener) this);
      StateHasChanged();
      return base.OnInitializedAsync();
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Detach((IScannedDetectionActionListener) this);
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Detach((ICheckProcessingActionListener) this);
      IgoodiReceiverInboundServer.GetIgoodiReceiverInboundServer.Detach((ICheckFailureProcessingActionListener) this);
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
    public FolderDto SelectedFolderItem { get; set; }
    private IEnumerable<FolderDto> _selectedItems; 
    public IEnumerable<FolderDto> SelectedItems 
    {
      get
      {
        if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<FolderDto>()))
          return _selectedItems;

        if(FolderState.Value.FolderList == null)
          return _selectedItems = Enumerable.Empty<FolderDto>();
        SelectedFolderItem = FolderState.Value.FolderList.FirstOrDefault();
        return _selectedItems = new List<FolderDto> { SelectedFolderItem };
      }
      set => _selectedItems = value;
    }
    protected void OnSelect(IEnumerable<FolderDto> folderItems)
    {
      SelectedFolderItem = folderItems.FirstOrDefault();
      SelectedItems = new List<FolderDto> { SelectedFolderItem };
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
      if(slackValue == "true")
        SlackService.SendMessageOnRandomAsync($"Reconstruction Scanned at:{DateTime.Now}");
    }

    public void Update(object sender, CheckProcessingEventArgs e)
    {
      #region Reconstruction

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

      #endregion

      #region Retexturing

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

      #endregion

      #region Maya

      List<string> mayas = new List<string>();
      foreach (var mayaFolderList in FolderState.Value.MayaFolderList)
      {
        Thread.Sleep(20);
        Dispatcher.Dispatch(action: new CreateProcessAction(mayaFolderList.Name, ProcessStep.Maya,
          ProcessState.Value.LastProcess, ProcessState.Value.ProcessList));
        mayas.Add(mayaFolderList.Name);
      }

      foreach (var maya in mayas)
      {
        Thread.Sleep(10);
        Dispatcher.Dispatch(new DeleteProcessAction(maya, ProcessStep.Maya));
      }

      #endregion

      #region Unity

      List<string> unities = new List<string>();
      foreach (var unityFolderList in FolderState.Value.UnityFolderList)
      {
        Thread.Sleep(20);
        Dispatcher.Dispatch(action: new CreateProcessAction(unityFolderList.Name, ProcessStep.Unity,
          ProcessState.Value.LastProcess, ProcessState.Value.ProcessList));
        unities.Add(unityFolderList.Name);
      }

      foreach (var unity in unities)
      {
        Thread.Sleep(10);
        Dispatcher.Dispatch(new DeleteProcessAction(unity, ProcessStep.Unity));
      }

      #endregion
    }

    public void Update(object sender, CheckFailureProcessingEventArgs e)
    {
      Dispatcher.Dispatch(new MoveProcessAction());
    }
  }
}
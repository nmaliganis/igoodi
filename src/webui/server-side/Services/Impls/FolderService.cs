using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using igoodi.receiver360.webui.Models.DTOs.Folders;
using igoodi.receiver360.webui.Services.Contracts;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using igoodi.receiver360.webui.Models.DTOs.Processes;
using Serilog;

namespace igoodi.receiver360.webui.Services.Impls
{

  public class FolderService : IFolderService
  {
    public IConfiguration Configuration { get; set; }
    public string RemoteAddr { get; private set; }
    public FolderService(IConfiguration configuration)
    {
      Configuration = configuration;
      OnCreated();
    }
    private void OnCreated()
    {
      RemoteAddr = Configuration["remote"];
    }

    public async Task<List<FolderDto>> GetFolderList()
    {
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();

      Log.Information(
        $"GetFolderList:" +
        "--FolderService--  @AboutComplete@ Message: Just Before GetFolderList");

      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_input_path")
        .Value;

      var reconstructionInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

      foreach (var reconstructionInputFile in reconstructionInputFiles)
      {
        int lastPosition = reconstructionInputFile.LastIndexOf('\\');
        string file = reconstructionInputFile.Substring(lastPosition + 1);

        int firstPosition = file.IndexOf('.');
        string key = file.Substring(0, firstPosition - 1);

        if (!files.ContainsKey(key))
        {
          files.Add(key, new List<string>()
          {
            file
          });
        }
        else
        {
          files[key].Add(file);
        }
      }

      List<FolderDto> returnValue = new List<FolderDto>();

      foreach (var file in files)
      {
        if (file.Value.Count <= 2)
        {
          returnValue.Add(new FolderDto()
          {
            DateCreated = DateTime.Now,
            Name = file.Key,
            IsFailed = false,
            Type = "Reconstruction"
          });
        }
      }

      return returnValue;
    }

    public async Task<List<FolderDto>> GetReconstructionFolderList()
    {
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();

      Log.Information(
        $"GetFolderList:" +
        "--FolderService--  @AboutComplete@ Message: Just Before GetFolderList");

      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_input_path")
        .Value;

      var returnValue = OkFiles(folderPath, files, ProcessStep.Reconstruction);

      return returnValue;
    }

    private static List<FolderDto> OkFiles(string folderPath, IDictionary<string, List<string>> files, ProcessStep step)
    {
      var reconstructionInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

      foreach (var reconstructionInputFile in reconstructionInputFiles)
      {
        int lastPosition = reconstructionInputFile.LastIndexOf('\\');
        string file = reconstructionInputFile.Substring(lastPosition + 1);

        int firstPosition = file.IndexOf('.');
        string key = file.Substring(0, firstPosition - 1);

        if (!files.ContainsKey(key))
        {
          files.Add(key, new List<string>()
          {
            file
          });
        }
        else
        {
          files[key].Add(file);
        }
      }

      List<FolderDto> returnValue = new List<FolderDto>();

      foreach (var file in files)
      {
        if (file.Value.Count <= 2)
        {
          returnValue.Add(new FolderDto()
          {
            DateCreated = DateTime.Now,
            Name = file.Key,
            IsFailed = false,
            Type = step.ToString()
          });
        }
      }

      return returnValue;
    }

    public async Task<List<FolderDto>> GetReconstructionFailedFolderList()
    {
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();

      Log.Information(
        $"GetFolderList:" +
        "--FolderService--  @AboutComplete@ Message: Just Before GetFolderList");

      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_input_path")
        .Value;

      var returnValue = FailedFiles(folderPath, files, ProcessStep.Reconstruction);

      return returnValue;
    }

    private static List<FolderDto> FailedFiles(string folderPath, IDictionary<string, List<string>> files, ProcessStep step)
    {
      var reconstructionInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

      foreach (var reconstructionInputFile in reconstructionInputFiles)
      {
        int lastPosition = reconstructionInputFile.LastIndexOf('\\');
        string file = reconstructionInputFile.Substring(lastPosition + 1);

        int firstPosition = file.IndexOf('.');
        string key = file.Substring(0, firstPosition - 1);

        if (!files.ContainsKey(key))
        {
          files.Add(key, new List<string>()
          {
            file
          });
        }
        else
        {
          files[key].Add(file);
        }
      }

      List<FolderDto> returnValue = new List<FolderDto>();

      foreach (var file in files)
      {
        if (file.Value.Count > 2)
        {
          if(file.Value.Any(x => x.EndsWith(".zip.fail")))
          {
            returnValue.Add(new FolderDto()
            {
              DateCreated = DateTime.Now,
              Name = file.Key,
              IsFailed = true,
              Type = step.ToString()
            });
          }
        }
      }

      return returnValue;
    }

    public async Task<List<FolderDto>> GetRetexturingFolderList()
    {
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();

      Log.Information(
        $"GetFolderList:" +
        "--FolderService--  @AboutComplete@ Message: Just Before GetFolderList");

      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_input_path")
        .Value;

      var returnValue = OkFiles(folderPath, files, ProcessStep.Retexturing);

      return returnValue;
    }

    public async Task<List<FolderDto>> GetRetexturingFailedFolderList()
    {
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();

      Log.Information(
        $"GetFolderList:" +
        "--FolderService--  @AboutComplete@ Message: Just Before GetFolderList");

      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_input_path")
        .Value;

      var returnValue = FailedFiles(folderPath, files, ProcessStep.Retexturing);

      return returnValue;
    }

    public async Task<List<FolderDto>> GetMayaFolderList()
    {
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();

      Log.Information(
        $"GetFolderList:" +
        "--FolderService--  @AboutComplete@ Message: Just Before GetFolderList");

      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_input_path")
        .Value;

      var returnValue = OkFiles(folderPath, files, ProcessStep.Maya);

      return returnValue;
    }

    public async Task<List<FolderDto>> GetMayaFailedFolderList()
    {
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();

      Log.Information(
        $"GetFolderList:" +
        "--FolderService--  @AboutComplete@ Message: Just Before GetFolderList");

      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_input_path")
        .Value;

      var returnValue = FailedFiles(folderPath, files, ProcessStep.Maya);

      return returnValue;
    }

    public async Task<List<FolderDto>> GetUnityFolderList()
    {
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();

      Log.Information(
        $"GetFolderList:" +
        "--FolderService--  @AboutComplete@ Message: Just Before GetFolderList");

      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_input_path")
        .Value;

      var returnValue = OkFiles(folderPath, files, ProcessStep.Unity);

      return returnValue;
    }

    public async Task<List<FolderDto>> GetUnityFailedFolderList()
    {
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();

      Log.Information(
        $"GetFolderList:" +
        "--FolderService--  @AboutComplete@ Message: Just Before GetFolderList");

      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_input_path")
        .Value;

      var returnValue = FailedFiles(folderPath, files, ProcessStep.Unity);

      return returnValue;
    }

    public Task<FolderDto> GetFolder(string name)
    {
      return null;
    }

    public async Task<ProcessDto> ProcessReconstructionScanFolder(string name, string destination)
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_input_path")
        .Value;

      var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_path")
        .Value +"\\" + destination;

      var reconstructionInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
      int bothFiles = 0;
      foreach (var reconstructionInputFile in reconstructionInputFiles)
      {
        string file = String.Empty;
        if (reconstructionInputFile.Contains(name))
        {
          try
          {
            int lastPosition = reconstructionInputFile.LastIndexOf('\\');
            file = reconstructionInputFile.Substring(lastPosition + 1);

            File.Copy(reconstructionInputFile, destFile + "\\" + file, true);
          }
          catch (Exception ex)
          {
            //Todo: Log ex
            return null;
          }
          bothFiles++;
        }

        if (bothFiles == 2)
        {
          return await Task.Run(() => new ProcessDto()
          {
            Path = reconstructionInputFile,
            Name = file,
            Process = Int32.Parse(destination),
            Step = ProcessStep.Reconstruction.ToString()
          });
        }
      }

      return null;
    }

    public async Task<ProcessDto> ProcessRetexturingScanFolder(string name, string destination)
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_input_path")
        .Value;

      var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_path")
        .Value +"\\" + destination;

      var retexturingInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
      int bothFiles = 0;
      foreach (var retexturingInputFile in retexturingInputFiles)
      {
        string file = String.Empty;
        if (retexturingInputFile.Contains(name))
        {
          try
          {
            int lastPosition = retexturingInputFile.LastIndexOf('\\');
            file = retexturingInputFile.Substring(lastPosition + 1);

            File.Copy(retexturingInputFile, destFile + "\\" + file, true);
          }
          catch (Exception ex)
          {
            //Todo: Log ex
            return null;
          }
          bothFiles++;
        }

        if (bothFiles == 2)
        {
          return await Task.Run(() => new ProcessDto()
          {
            Path = retexturingInputFile,
            Name = file,
            Process = Int32.Parse(destination),
            Step = ProcessStep.Retexturing.ToString()
          });
        }
      }

      return null;
    }

    public async Task<ProcessDto> ProcessMayaScanFolder(string name, string destination)
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_input_path")
        .Value;

      var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_path")
        .Value +"\\" + destination;

      var mayaInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
      int bothFiles = 0;
      foreach (var mayaInputFile in mayaInputFiles)
      {
        string file = String.Empty;
        if (mayaInputFile.Contains(name))
        {
          try
          {
            int lastPosition = mayaInputFile.LastIndexOf('\\');
            file = mayaInputFile.Substring(lastPosition + 1);

            File.Copy(mayaInputFile, destFile + "\\" + file, true);
          }
          catch (Exception ex)
          {
            //Todo: Log ex
            return null;
          }
          bothFiles++;
        }

        if (bothFiles == 2)
        {
          return await Task.Run(() => new ProcessDto()
          {
            Path = mayaInputFile,
            Name = file,
            Process = Int32.Parse(destination),
            Step = ProcessStep.Maya.ToString()
          });
        }
      }

      return null;
    }

    public async Task<ProcessDto> ProcessUnityScanFolder(string name, string destination)
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_input_path")
        .Value;

      var destFile = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_path")
        .Value +"\\" + destination;

      var unityInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
      int bothFiles = 0;
      foreach (var unityInputFile in unityInputFiles)
      {
        string file = String.Empty;
        if (unityInputFile.Contains(name))
        {
          try
          {
            int lastPosition = unityInputFile.LastIndexOf('\\');
            file = unityInputFile.Substring(lastPosition + 1);

            File.Copy(unityInputFile, destFile + "\\" + file, true);
          }
          catch (Exception ex)
          {
            //Todo: Log ex
            return null;
          }
          bothFiles++;
        }

        if (bothFiles == 2)
        {
          return await Task.Run(() => new ProcessDto()
          {
            Path = unityInputFile,
            Name = file,
            Process = Int32.Parse(destination),
            Step = ProcessStep.Unity.ToString()
          });
        }
      }

      return null;
    }

    public async Task ProcessReconstructionDelete(string name)
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_input_path")
        .Value;

      var reconstructionInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
      
      foreach (var reconstructionInputFile in reconstructionInputFiles)
      {
        string file = String.Empty;
        if (reconstructionInputFile.Contains(name))
        {
          try
          {
            File.Delete(reconstructionInputFile);
          }
          catch (Exception ex)
          {
            //Todo
          }
        }
      }
    }

    public async Task ProcessRetexturingDelete(string name)
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_input_path")
        .Value;

      var reconstructionInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
      
      foreach (var reconstructionInputFile in reconstructionInputFiles)
      {
        string file = String.Empty;
        if (reconstructionInputFile.Contains(name))
        {
          try
          {
            int lastPosition = reconstructionInputFile.LastIndexOf('\\');
            file = reconstructionInputFile.Substring(lastPosition + 1);

            File.Delete(reconstructionInputFile);
          }
          catch (Exception ex)
          {
            //Todo
          }
        }
      }
    }

    public async Task ProcessMayaDelete(string name)
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_input_path")
        .Value;

      var mayaInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
      
      foreach (var mayaInputFile in mayaInputFiles)
      {
        string file = String.Empty;
        if (mayaInputFile.Contains(name))
        {
          try
          {
            int lastPosition = mayaInputFile.LastIndexOf('\\');
            file = mayaInputFile.Substring(lastPosition + 1);

            File.Delete(mayaInputFile);
          }
          catch (Exception ex)
          {
            //Todo
          }
        }
      }
    }

    public async Task ProcessUnityDelete(string name)
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_input_path")
        .Value;

      var unityInputFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
      
      foreach (var unityInputFile in unityInputFiles)
      {
        string file = String.Empty;
        if (unityInputFile.Contains(name))
        {
          try
          {
            int lastPosition = unityInputFile.LastIndexOf('\\');
            file = unityInputFile.Substring(lastPosition + 1);

            File.Delete(unityInputFile);
          }
          catch (Exception ex)
          {
            //Todo
          }
        }
      }
    }

    public async Task ProcessReconstructionFailed()
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_path")
        .Value;     
      
      var folderInputPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:reconstruction_input_path")
        .Value;
      //1
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();
      var returnValue = FailedFiles(folderPath + "\\1", files, ProcessStep.Reconstruction);

      List<string> filesToBeMoved;

      foreach (var t in returnValue)
      {
        filesToBeMoved = files[t.Name];
        foreach (var fileToBeMoved in filesToBeMoved)
        {
          File.Move(folderPath + "\\1" + "\\" + fileToBeMoved, folderInputPath + "\\" + fileToBeMoved, true);
        }
      }

      //2
      returnValue = FailedFiles(folderPath + "\\2", files, ProcessStep.Reconstruction);

      foreach (var t in returnValue)
      {
        filesToBeMoved = files[t.Name];
        foreach (var fileToBeMoved in filesToBeMoved)
        {
          File.Move(folderPath + "\\2" + "\\" + fileToBeMoved, folderInputPath + "\\" + fileToBeMoved, true);
        }
      }
    }

    public async Task ProcessRetexturingFailed()
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_path")
        .Value;     
      
      var folderInputPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:retexturing_input_path")
        .Value;
      //1
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();
      var returnValue = FailedFiles(folderPath + "\\1", files, ProcessStep.Reconstruction);

      List<string> filesToBeMoved;

      foreach (var t in returnValue)
      {
        filesToBeMoved = files[t.Name];
        foreach (var fileToBeMoved in filesToBeMoved)
        {
          File.Move(folderPath + "\\1" + "\\" + fileToBeMoved, folderInputPath + "\\" + fileToBeMoved, true);
        }
      }

      //2
      returnValue = FailedFiles(folderPath + "\\2", files, ProcessStep.Reconstruction);

      foreach (var t in returnValue)
      {
        filesToBeMoved = files[t.Name];
        foreach (var fileToBeMoved in filesToBeMoved)
        {
          File.Move(folderPath + "\\2" + "\\" + fileToBeMoved, folderInputPath + "\\" + fileToBeMoved, true);
        }
      }
    }

    public async Task ProcessMayaFailed()
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_path")
        .Value;     
      
      var folderInputPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:maya_input_path")
        .Value;
      //1
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();
      var returnValue = FailedFiles(folderPath + "\\1", files, ProcessStep.Maya);

      List<string> filesToBeMoved;

      foreach (var t in returnValue)
      {
        filesToBeMoved = files[t.Name];
        foreach (var fileToBeMoved in filesToBeMoved)
        {
          File.Move(folderPath + "\\1" + "\\" + fileToBeMoved, folderInputPath + "\\" + fileToBeMoved, true);
        }
      }

      //2
      returnValue = FailedFiles(folderPath + "\\2", files, ProcessStep.Maya);

      foreach (var t in returnValue)
      {
        filesToBeMoved = files[t.Name];
        foreach (var fileToBeMoved in filesToBeMoved)
        {
          File.Move(folderPath + "\\2" + "\\" + fileToBeMoved, folderInputPath + "\\" + fileToBeMoved, true);
        }
      }
    }

    public async Task ProcessUnityFailed()
    {
      var folderPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_path")
        .Value;     
      
      var folderInputPath = Configuration.GetSection($"{Configuration["env"]}:ProcessingPaths:unity_input_path")
        .Value;
      //1
      IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();
      var returnValue = FailedFiles(folderPath + "\\1", files, ProcessStep.Unity);

      List<string> filesToBeMoved;

      foreach (var t in returnValue)
      {
        filesToBeMoved = files[t.Name];
        foreach (var fileToBeMoved in filesToBeMoved)
        {
          File.Move(folderPath + "\\1" + "\\" + fileToBeMoved, folderInputPath + "\\" + fileToBeMoved, true);
        }
      }

      //2
      returnValue = FailedFiles(folderPath + "\\2", files, ProcessStep.Unity);

      foreach (var t in returnValue)
      {
        filesToBeMoved = files[t.Name];
        foreach (var fileToBeMoved in filesToBeMoved)
        {
          File.Move(folderPath + "\\2" + "\\" + fileToBeMoved, folderInputPath + "\\" + fileToBeMoved, true);
        }
      }
    }
  }
}
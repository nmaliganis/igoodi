using System.IO;

namespace igoodi.receiver360.webui.Store.Process
{
  public sealed class FileChecker
  {
    private static FileChecker _instance = new FileChecker();

    private FileChecker()
    {

    }

    public static FileChecker Checker => _instance;

    public bool ExistFile(string nameFile, string destination)
    {
      bool returnValue = false;
      var destinationFilesFiles = Directory.GetFiles(destination, "*.*", SearchOption.TopDirectoryOnly);

      foreach (var filesFile in destinationFilesFiles)
      {
        if (filesFile.Contains(nameFile))
        {
          returnValue = true;
          break;
        }
      }

      return returnValue;
    }
  }
}

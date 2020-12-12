using igoodi.receiver360.webui.Models.DTOs.Processes;

namespace igoodi.receiver360.webui.Store.Process.Actions.CreateProcess
{
  public class CreateProcessSuccessAction
  {
    public ProcessDto Process { get; private set; }

    public CreateProcessSuccessAction(ProcessDto process)
    {
      Process = process;
    }
  }

  public class ReconstructionSuccessAction
  {
    public ProcessDto Process { get; private set; }
    public int ReconstructionLast { get; private set; }
    public int ReconstructionMax { get; private set; }

    public ReconstructionSuccessAction(ProcessDto process, int reconstructionLast, int reconstructionMax)
    {
      Process = process;
      ReconstructionLast = reconstructionLast;
      ReconstructionMax = reconstructionMax;
    }
  }

  public class RetexturingSuccessAction
  {
    public ProcessDto Process { get; private set; }
    public int RetexturingLast { get; private set; }
    public int RetexturingMax { get; private set; }

    public RetexturingSuccessAction(ProcessDto process, int retexturingLast, int retexturingMax)
    {
      Process = process;
      RetexturingLast = retexturingLast;
      RetexturingMax = retexturingMax;
    }
  }

  public class MayaSuccessAction
  {
    public ProcessDto Process { get; private set; }
    public int MayaLast { get; private set; }
    public int MayaMax { get; private set; }

    public MayaSuccessAction(ProcessDto process, int mayaLast, int mayaMax)
    {
      Process = process;
      MayaLast = mayaLast;
      MayaMax = mayaMax;
    }
  }

  public class UnitySuccessAction
  {
    public ProcessDto Process { get; private set; }
    public int UnityLast { get; private set; }
    public int UnityMax { get; private set; }

    public UnitySuccessAction(ProcessDto process, int unityLast, int unityMax)
    {
      Process = process;
      UnityLast = unityLast;
      UnityMax = unityMax;
    }
  }
}
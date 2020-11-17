using System;
using igoodi.receiver360.webui.Commanding.Events.Args;
using igoodi.receiver360.webui.Commanding.Listeners;

namespace igoodi.receiver360.webui.Commanding.Servers.Base
{
  public abstract class IIgoodiReceiverInboundServer
  {
    public event EventHandler<ScannedDetectionEventArgs> ScannedDetector;
    public event EventHandler<CheckIncomingDetectionEventArgs> CheckIncomingDetector;
    public event EventHandler<CheckProcessingEventArgs> CheckProcessingDetector;
    public event EventHandler<CheckFailureProcessingEventArgs> CheckFailureProcessingDetector;
    public event EventHandler<CheckCognitoDetectionEventArgs> CheckCognitoDetector;

    #region Scanned detection Event Manipulation

    private void OnScannedDetection(ScannedDetectionEventArgs e)
    {
      ScannedDetector?.Invoke(this, e);
    }

    public void RaiseScannedDetection(string payload)
    {
      OnScannedDetection(new ScannedDetectionEventArgs(payload, true, ""));
    }

    public void Attach(IScannedDetectionActionListener listener)
    {
        ScannedDetector += listener.Update;
    }

    public void Detach(IScannedDetectionActionListener listener)
    {
        ScannedDetector -= listener.Update;
    }

    #endregion

    #region Check Processing Event Manipulation

    private void OnCheckProcessingDetection(CheckProcessingEventArgs e)
    {
      CheckProcessingDetector?.Invoke(this, e);
    }

    public void RaiseCheckProcessingDetection(string payload, int process)
    {
      OnCheckProcessingDetection(new CheckProcessingEventArgs(payload, true, process));
    }

    public void Attach(ICheckProcessingActionListener listener)
    {
      CheckProcessingDetector += listener.Update;
    }

    public void Detach(ICheckProcessingActionListener listener)
    {
      CheckProcessingDetector -= listener.Update;
    }

    #endregion

    #region Check Failure Processing Event Manipulation

    private void OnCheckFailureProcessingDetection(CheckFailureProcessingEventArgs e)
    {
      CheckFailureProcessingDetector?.Invoke(this, e);
    }

    public void RaiseCheckFailureProcessingDetection(string payload, int process)
    {
      OnCheckFailureProcessingDetection(new CheckFailureProcessingEventArgs(payload, true, process));
    }

    public void Attach(ICheckFailureProcessingActionListener listener)
    {
      CheckFailureProcessingDetector += listener.Update;
    }

    public void Detach(ICheckFailureProcessingActionListener listener)
    {
      CheckFailureProcessingDetector -= listener.Update;
    }

    #endregion

    #region Check Incoming detection Event Manipulation

    private void OnCheckIncomingDetection(CheckIncomingDetectionEventArgs e)
    {
      CheckIncomingDetector?.Invoke(this, e);
    }

    public void RaiseCheckIncomingDetection(string payload)
    {
      OnCheckIncomingDetection(new CheckIncomingDetectionEventArgs(payload, true));
    }

    public void Attach(ICheckIncomingDetectionActionListener listener)
    {
      CheckIncomingDetector += listener.Update;
    }

    public void Detach(ICheckIncomingDetectionActionListener listener)
    {
      CheckIncomingDetector -= listener.Update;
    }

    #endregion

    #region Check Cognito detection Event Manipulation

    private void OnCheckCognitoDetection(CheckCognitoDetectionEventArgs e)
    {
      CheckCognitoDetector?.Invoke(this, e);
    }

    public void RaiseCheckCognitoDetection(string payload)
    {
      OnCheckCognitoDetection(new CheckCognitoDetectionEventArgs(payload, true));
    }

    public void Attach(ICheckCognitoDetectionActionListener listener)
    {
      CheckCognitoDetector += listener.Update;
    }

    public void Detach(ICheckCognitoDetectionActionListener listener)
    {
      CheckCognitoDetector -= listener.Update;
    }

    #endregion
  }
}
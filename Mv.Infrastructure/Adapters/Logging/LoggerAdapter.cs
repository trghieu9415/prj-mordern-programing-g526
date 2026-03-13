using Mv.Application.Ports.Logging;

namespace Mv.Infrastructure.Adapters.Logging;

public class LoggerAdapter<T> : IAppLogger<T> {
  public void LogBusinessInformation(string message, params object[] args) {
    throw new NotImplementedException();
  }

  public void LogBusinessError(Exception ex, string message, params object[] args) {
    throw new NotImplementedException();
  }

  public void LogSystemWarning(string message, params object[] args) {
    throw new NotImplementedException();
  }

  public void LogSystemError(Exception ex, string message, params object[] args) {
    throw new NotImplementedException();
  }
}

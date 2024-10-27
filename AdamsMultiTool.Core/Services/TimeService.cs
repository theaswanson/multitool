namespace AdamsMultiTool.Core.Services;

public class TimeService(TimeProvider timeProvider)
{
    public string GetCurrentTimeString(TimeFormat format) =>
        format switch
        {
            TimeFormat.UTC => timeProvider.GetUtcNow().ToString(),
            TimeFormat.UnixTimestamp => timeProvider.GetUtcNow().UtcTicks.ToString(),
            _ => timeProvider.GetLocalNow().ToString()
        };
}
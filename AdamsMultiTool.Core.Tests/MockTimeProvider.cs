namespace AdamsMultiTool.Core.Tests;

public class MockTimeProvider : TimeProvider
{
    private DateTimeOffset _utcNow;
    private TimeZoneInfo _localTimeZone;
    
    public override TimeZoneInfo LocalTimeZone => _localTimeZone;

    public MockTimeProvider() : this(DateTimeOffset.UtcNow, TimeZoneInfo.Local)
    {
    }

    public MockTimeProvider(DateTimeOffset utcNow, TimeZoneInfo localTimeZone)
    {
        _utcNow = utcNow;
        _localTimeZone = localTimeZone;
    }

    public void SetUtcNow(DateTimeOffset dateTimeOffset) => _utcNow = dateTimeOffset;
    public void SetLocalTimezone(TimeZoneInfo localTimeZone) => _localTimeZone = localTimeZone;
    
    public override DateTimeOffset GetUtcNow() => _utcNow;
}
using AdamsMultiTool.Core.Services;
using FluentAssertions;

namespace AdamsMultiTool.Core.Tests.Services;

[TestFixture]
public class TimeServiceTests
{
    private TimeService _timeService;
    private MockTimeProvider _mockTimeProvider;

    [SetUp]
    public void Setup()
    {
        _mockTimeProvider = new MockTimeProvider();
        _timeService = new TimeService(_mockTimeProvider);
    }

    [Test]
    public void GivenDefaultFormat_PrintsTimeInLocalTimeZone()
    {
        var now = new DateTime(2024, 1, 2, 3, 4, 5, DateTimeKind.Utc);
        _mockTimeProvider.SetUtcNow(now);
        
        var localTimeZone = TimeZoneInfo.CreateCustomTimeZone(
            "custom-time-zone",
            TimeSpan.FromHours(-1),
            "Custom Time Zone",
            "CTZ");

        _mockTimeProvider.SetLocalTimezone(localTimeZone);

        var result = _timeService.GetCurrentTimeString(TimeFormat.Default);

        result.Should().Be("1/2/2024 2:04:05 AM -01:00");
    }
    
    [Test]
    public void GivenUTCFormat_PrintsTimeInUTC()
    {
        var now = new DateTime(2024, 1, 2, 3, 4, 5, DateTimeKind.Utc);
        _mockTimeProvider.SetUtcNow(now);
        
        var localTimeZone = TimeZoneInfo.CreateCustomTimeZone(
            "custom-time-zone",
            TimeSpan.FromHours(-1),
            "Custom Time Zone",
            "CTZ");

        _mockTimeProvider.SetLocalTimezone(localTimeZone);

        var result = _timeService.GetCurrentTimeString(TimeFormat.UTC);

        result.Should().Be("1/2/2024 3:04:05 AM +00:00");
    }
    
    [Test]
    public void GivenUnixTimestamp_PrintsTimestamp()
    {
        var now = new DateTime(1234567890, DateTimeKind.Utc);
        _mockTimeProvider.SetUtcNow(now);
        
        // Local timezone should be ignored
        var localTimeZone = TimeZoneInfo.CreateCustomTimeZone(
            "custom-time-zone",
            TimeSpan.FromHours(-1),
            "Custom Time Zone",
            "CTZ");

        _mockTimeProvider.SetLocalTimezone(localTimeZone);

        var result = _timeService.GetCurrentTimeString(TimeFormat.UnixTimestamp);

        result.Should().Be("1234567890");
    }
}
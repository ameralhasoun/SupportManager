using Shouldly;
using Xunit;
using static SupportManager.Web.Areas.Teams.Pages.Report.DailyModel;

namespace SupportManager.Web.Tests
{
    public partial class HandlerTests
    {
        public class RoundTimestampToNearestMinuteTests
        {
            [Fact]
            public void Rounds_down_when_seconds_less_than_30()
            {
                var input = new DateTimeOffset(2025, 1, 1, 10, 15, 29, TimeSpan.FromHours(1));

                var result = Handler.RoundTimestampToNearestMinute(input);

                result.ShouldBe(new DateTimeOffset(2025, 1, 1, 10, 15, 0, TimeSpan.FromHours(1)));
            }

            [Fact]
            public void Rounds_up_when_seconds_are_30_or_more()
            {
                var input = new DateTimeOffset(2025, 1, 1, 10, 15, 30, TimeSpan.FromHours(1));

                var result = Handler.RoundTimestampToNearestMinute(input);

                result.ShouldBe(new DateTimeOffset(2025, 1, 1, 10, 16, 0, TimeSpan.FromHours(1)));
            }

            [Fact]
            public void Rounds_up_across_hour_boundary()
            {
                var input = new DateTimeOffset(2025, 1, 1, 10, 59, 45, TimeSpan.Zero);

                var result = Handler.RoundTimestampToNearestMinute(input);

                result.ShouldBe(new DateTimeOffset(2025, 1, 1, 11, 0, 0, TimeSpan.Zero));
            }
        }
    }
}

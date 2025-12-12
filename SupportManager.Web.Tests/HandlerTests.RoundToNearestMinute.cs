using Shouldly;
using Xunit;
using static SupportManager.Web.Areas.Teams.Pages.Report.DailyModel;

namespace SupportManager.Web.Tests
{
    public partial class HandlerTests
    {
        public class RoundToNearestMinute
        {
            [Fact]
            public void Rounds_down_when_less_than_30_seconds()
            {
                var input = TimeSpan.FromSeconds(29);

                var result = Handler.RoundToNearestMinute(input);

                result.ShouldBe(TimeSpan.Zero);
            }

            [Fact]
            public void Rounds_up_at_30_seconds()
            {
                var input = TimeSpan.FromSeconds(30);

                var result = Handler.RoundToNearestMinute(input);

                result.ShouldBe(TimeSpan.FromMinutes(1));
            }

            [Fact]
            public void Rounds_up_when_more_than_30_seconds()
            {
                var input = TimeSpan.FromSeconds(91); // 1:31

                var result = Handler.RoundToNearestMinute(input);

                result.ShouldBe(TimeSpan.FromMinutes(2));
            }

            [Fact]
            public void Exact_minutes_are_not_changed()
            {
                var input = TimeSpan.FromMinutes(5);

                var result = Handler.RoundToNearestMinute(input);

                result.ShouldBe(TimeSpan.FromMinutes(5));
            }
        }
        
    }
}

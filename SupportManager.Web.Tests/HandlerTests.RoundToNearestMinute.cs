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
                // Arrange
                var input = TimeSpan.FromSeconds(29);

                // Act
                var result = Handler.RoundToNearestMinute(input);

                // Assert
                result.ShouldBe(TimeSpan.Zero);
            }

            [Fact]
            public void Rounds_up_at_30_seconds()
            {
                // Arrange
                var input = TimeSpan.FromSeconds(30);

                // Act
                var result = Handler.RoundToNearestMinute(input);

                // Assert
                result.ShouldBe(TimeSpan.FromMinutes(1));
            }

            [Fact]
            public void Rounds_up_when_more_than_30_seconds()
            {
                // Arrange
                var input = TimeSpan.FromSeconds(91); // 1:31

                // Act
                var result = Handler.RoundToNearestMinute(input);

                // Assert
                result.ShouldBe(TimeSpan.FromMinutes(2));
            }

            [Fact]
            public void Exact_minutes_are_not_changed()
            {
                // Arrange
                var input = TimeSpan.FromMinutes(5);

                // Act
                var result = Handler.RoundToNearestMinute(input);

                // Assert
                result.ShouldBe(TimeSpan.FromMinutes(5));
            }
        }
        
    }
}

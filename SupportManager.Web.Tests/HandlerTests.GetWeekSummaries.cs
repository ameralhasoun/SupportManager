using Shouldly;
using Xunit;
using static SupportManager.Web.Areas.Teams.Pages.Report.DailyModel;

namespace SupportManager.Web.Tests
{
    public partial class HandlerTests
    {
        public class GetWeekSummaries
        {
            [Fact]
            public void Returns_Summaries_For_Every_Slot()
            {
                // Arrange
                var startTime = DateTimeOffset.Now;

                var week = new Result.Week
                {
                    Slots =
                    [
                        new() { StartTime = startTime, EndTime = startTime.AddHours(12), GroupingKey = "A", Participations = [] },
                        new() { StartTime = startTime.AddHours(36), EndTime = startTime.AddHours(48), GroupingKey = "B", Participations = [] },
                        new() { StartTime = startTime.AddHours(50), EndTime = startTime.AddHours(60), GroupingKey = "C", Participations = [] },
                    ]
                };

                // Act
                var summaries = Handler.GetWeekSummaries(week);

                // Assert
                summaries.Count.ShouldBe(3);

                // summaries.ShouldContain(s => s.GroupingKey == "B" && s.TotalValue == 30);
            }


            // public static IEnumerable<object[]> GetNumberOfSlotsData()
            // {
            //     for (int i = 1; i <= 500; i++)
            //     {
            //         yield return new object[] { i };
            //     }
            // }

            // [Theory]
            // [MemberData(nameof(GetNumberOfSlotsData))]
            // public void Returns_Summaries_With_TotalValue_Sum(int numberOfSlots)
            // {
            //     // Arrange
            //     var startTime = DateTimeOffset.Now;

            //     var week = new Result.Week
            //     {
            //         Slots =
            //         [
            //             new() { StartTime = startTime, EndTime = startTime.AddHours(12), GroupingKey = "A", Participations = [] },
            //             new() { StartTime = startTime.AddHours(36), EndTime = startTime.AddHours(48), GroupingKey = "B", Participations = [] },
            //             new() { StartTime = startTime.AddHours(50), EndTime = startTime.AddHours(60), GroupingKey = "C", Participations = [] },
            //      ]
            //     };

            //     // Act
            //     var summaries = Handler.GetWeekSummaries(week);

            //     // Assert
            //     summaries.Count.ShouldBe(3);
            // }
        }
    }
}

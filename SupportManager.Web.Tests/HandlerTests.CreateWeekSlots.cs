using Shouldly;
using Xunit;
using static SupportManager.Web.Areas.Teams.Pages.Report.DailyModel;

namespace SupportManager.Web.Tests
{
    public partial class HandlerTests
    {
        public class CreateWeekSlots
        {
            [Fact]
            public void Creates_expected_number_of_week_slots()
            {
                // Act
                var slots = Handler.CreateWeekSlots();

                // Assert
                slots.Count.ShouldBe(12);
            }

            [Fact]
            public void First_slot_is_monday_kantooruren_at_07_30()
            {
                // Act
                var slots = Handler.CreateWeekSlots();
                var firstSlot = slots[0];

                // Assert
                firstSlot.GroupingKey.ShouldBe("Kantooruren");

                var expectedStart = TimeSpan.FromDays(1).Add(TimeSpan.FromHours(7.5));

                firstSlot.Start.ShouldBe(expectedStart);
            }

            [Fact]
            public void Contains_doordeweeks_slot_at_16_30()
            {
                // Act
                var slots = Handler.CreateWeekSlots();

                var doordeweeksSlot = slots.First(s =>
                    s.GroupingKey == "Doordeweeks" &&
                    s.Start.Hours == 16 &&
                    s.Start.Minutes == 30);

                // Assert
                doordeweeksSlot.ShouldNotBeNull();
            }

            [Fact]
            public void Contains_three_weekend_slots()
            {
                // Act
                var slots = Handler.CreateWeekSlots();

                var weekendSlots = slots.Where(s => s.GroupingKey == "Weekend").ToList();

                // Assert
                weekendSlots.Count.ShouldBe(3);
            }

            [Fact]
            public void Weekend_starts_on_friday_at_16_30()
            {
                // Act
                var slots = Handler.CreateWeekSlots();

                var weekendStart = slots.First(s => s.GroupingKey == "Weekend");

                var expectedStart =TimeSpan.FromDays(5).Add(TimeSpan.FromHours(16.5));

                // Assert
                weekendStart.Start.ShouldBe(expectedStart);
            }

            [Fact]
            public void Sunday_weekend_slot_is_normalized_to_day_7()
            {
                // Act
                var slots = Handler.CreateWeekSlots();

                var sundaySlot = slots.Last(s =>
                    s.GroupingKey == "Weekend" &&
                    s.Start.Hours == 7 &&
                    s.Start.Minutes == 30);

                // Assert
                sundaySlot.Start.Days.ShouldBe(7);
            }
        }
    }
}

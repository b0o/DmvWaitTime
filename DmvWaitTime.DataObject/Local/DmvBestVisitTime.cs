namespace DmvWaitTime.DataObject.Local
{
    public class DmvBestVisitTime
    {
        public int BranchId { get; set; }

        public DayTime BestDateTimeOfWeek { get; set; }

        public int? BestDateTimeOfWeekWaitInMinute { get; set; }

        public Time BestTimeOfDay { get; set; }

        public int? BestTimeOfDayWaitInMinute { get; set; }
    }
}

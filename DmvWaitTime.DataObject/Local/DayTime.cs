using System;

namespace DmvWaitTime.DataObject.Local
{
    public class DayTime
    {
        public DayTime(DayOfWeek day, Time time)
        {
            Day = day;
            Time = time;
        }

        public DayOfWeek Day { get; }

        public Time Time { get; }

        public override bool Equals(object other)
        {
            var otherMyDayTime = other as DayTime;
            if (otherMyDayTime == null)
                return false;
            return otherMyDayTime.Day == Day && otherMyDayTime.Time == Time;
        }

        public override int GetHashCode()
        {
            return int.Parse(((int)Day) + Time.GetHashCode().ToString());
        }
    }
}

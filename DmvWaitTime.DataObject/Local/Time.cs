namespace DmvWaitTime.DataObject.Local
{
    public class Time
    {
        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public int Hour { get; }

        public int Minute { get; }

        public override bool Equals(object other)
        {
            var otherMyTime = other as Time;
            if (otherMyTime == null)
                return false;
            return Hour == otherMyTime.Hour && Minute == otherMyTime.Minute;
        }

        public override int GetHashCode()
        {
            return int.Parse(Hour + Minute.ToString());
        }
    }
}

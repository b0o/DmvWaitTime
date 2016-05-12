using System;
using System.Collections.Generic;
using System.Linq;
using DmvWaitTime.DataObject.Local;

namespace DmvWaitTime.Service
{
    class DmvBestVisitTimeService : IDmvBestVisitTimeService
    {
        public IEnumerable<DmvBestVisitTime> GetDmvBestVisitTimes(IEnumerable<CurrentDmvWaitTimes> dmvWaitTimes)
        {
            Dictionary<int, Dictionary<DateTime, int>> branchWaitTimeInfo = new Dictionary<int, Dictionary<DateTime, int>>();

            foreach (var dmvWaitTime in dmvWaitTimes)
            {
                foreach (var branchWaitTime in dmvWaitTime.DmvWaitTimes)
                {
                    if (!branchWaitTimeInfo.ContainsKey(branchWaitTime.BranchId))
                    {
                        branchWaitTimeInfo.Add(branchWaitTime.BranchId, new Dictionary<DateTime, int>() {
                            { dmvWaitTime.CurrentDateTime, GetWaitTimeInt(branchWaitTime.NonAppointmentWaitTimeString) }
                        });
                    }
                    else
                    {
                        branchWaitTimeInfo[branchWaitTime.BranchId][dmvWaitTime.CurrentDateTime] =
                            GetWaitTimeInt(branchWaitTime.NonAppointmentWaitTimeString);
                    }
                }
            }

            foreach (var branchInfo in branchWaitTimeInfo)
            {
                yield return GetDmvBestVisitTime(branchInfo);
            }
        }

        private int GetWaitTimeInt(string nonAppointmentWaitTimeString)
        {
            return Convert.ToInt32(nonAppointmentWaitTimeString);
        }

        private DmvBestVisitTime GetDmvBestVisitTime(KeyValuePair<int, Dictionary<DateTime, int>> branchInfo)
        {
            DmvBestVisitTime dmvBestVisitTime = new DmvBestVisitTime
            {
                BranchId = branchInfo.Key
            };

            GetBestVisitTime(dmvBestVisitTime, branchInfo.Value);

            return dmvBestVisitTime;
        }

        private void GetBestVisitTime(DmvBestVisitTime dmvBestVisitTime, Dictionary<DateTime, int> dateTimeWaitTimeDictionary)
        {
            Dictionary<Time, List<int>> timeWaitTimeDictionary = new Dictionary<Time, List<int>>();

            Dictionary<DayTime, List<int>> dayTimeWaitTimeDictionary = new Dictionary<DayTime, List<int>>();

            FillDictionaries(timeWaitTimeDictionary, dayTimeWaitTimeDictionary, dateTimeWaitTimeDictionary);

            CalculateBestVisitTime(dmvBestVisitTime, timeWaitTimeDictionary, dayTimeWaitTimeDictionary);
        }
       
        private void FillDictionaries(Dictionary<Time, List<int>> timeWaitTimeDictionary, Dictionary<DayTime, List<int>> dayTimeWaitTimeDictionary, Dictionary<DateTime, int> dateTimeWaitTimeDictionary)
        {
            foreach (var dateTimeWaitTime in dateTimeWaitTimeDictionary)
            {
                Time timeKey = new Time(dateTimeWaitTime.Key.Hour, dateTimeWaitTime.Key.Minute);

                DayTime dayTimeKey = new DayTime(dateTimeWaitTime.Key.DayOfWeek, timeKey);

                if (!timeWaitTimeDictionary.ContainsKey(timeKey))
                {
                    timeWaitTimeDictionary.Add(timeKey, new List<int> { dateTimeWaitTime.Value });
                }
                else
                {
                    timeWaitTimeDictionary[timeKey].Add(dateTimeWaitTime.Value);
                }

                if (!dayTimeWaitTimeDictionary.ContainsKey(dayTimeKey))
                {
                    dayTimeWaitTimeDictionary.Add(dayTimeKey, new List<int> { dateTimeWaitTime.Value });
                }
                else
                {
                    dayTimeWaitTimeDictionary[dayTimeKey].Add(dateTimeWaitTime.Value);
                }
            }
        }

        private void CalculateBestVisitTime(DmvBestVisitTime dmvBestVisitTime, Dictionary<Time, List<int>> timeWaitTimeDictionary, Dictionary<DayTime, List<int>> dayTimeWaitTimeDictionary)
        {
            foreach (var timeWaitTime in timeWaitTimeDictionary)
            {
                double average = timeWaitTime.Value.Average();

                if (timeWaitTime.Key.Hour <= 9 || timeWaitTime.Key.Hour >= 17)
                    continue;

                if (dmvBestVisitTime.BestTimeOfDayWaitInMinute == null ||
                    dmvBestVisitTime.BestTimeOfDayWaitInMinute > average)
                {
                    dmvBestVisitTime.BestTimeOfDay = timeWaitTime.Key;

                    dmvBestVisitTime.BestTimeOfDayWaitInMinute = Convert.ToInt32(average);
                }
            }

            foreach (var dayTimeWaitTime in dayTimeWaitTimeDictionary)
            {
                double average = dayTimeWaitTime.Value.Average();

                if (dayTimeWaitTime.Key.Time.Hour <= 9 || dayTimeWaitTime.Key.Time.Hour >= 17)
                    continue;

                if (dmvBestVisitTime.BestDateTimeOfWeekWaitInMinute == null ||
                    dmvBestVisitTime.BestDateTimeOfWeekWaitInMinute > average)
                {
                    dmvBestVisitTime.BestDateTimeOfWeek = dayTimeWaitTime.Key;

                    dmvBestVisitTime.BestDateTimeOfWeekWaitInMinute = Convert.ToInt32(average);
                }
            }
        }
    }
}

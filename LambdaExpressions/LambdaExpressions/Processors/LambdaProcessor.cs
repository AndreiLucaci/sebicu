using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LambdaExpressions.ModelBuilders;
using LambdaExpressions.Models;

namespace LambdaExpressions.Processors
{
    public class LambdaProcessor : ILambdaProcessor
    {
        private List<MonitoredData> _monitoredDatas;

        public int CountMonitoredDays()
        {
            return
                _monitoredDatas
                    .GroupBy(x => x.StartTime.Date)
                    .Select(x => x.Key)
                    .Union(_monitoredDatas.GroupBy(x => x.EndTime.Date).Select(x => x.Key))
                    .Count();
        }

        public Dictionary<string, int> CountMonitoredDaysPerActivity()
        {
            return
                _monitoredDatas
                    .GroupBy(x => x.ActivityLabel)
                    .ToDictionary(x => x.Key, x => x.Count());
        }

        public IEnumerable<Tuple<DateTime, string, int>> CountPerDayEachActivity()
        {
            return
                _monitoredDatas
                    .GroupBy(x => new {x.StartTime.Date, x.ActivityLabel})
                    .Union(_monitoredDatas.GroupBy(x => new {x.EndTime.Date, x.ActivityLabel}))
                    .Select(x => Tuple.Create(x.Key.Date, x.Key.ActivityLabel, x.Count()));
        }

        public Dictionary<string, TimeSpan> CountActivityDuration()
        {
            return
                _monitoredDatas.GroupBy(x => x.ActivityLabel)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Aggregate(new TimeSpan(), (span, data) => span.Add(data.Duration)));
        }

        public IEnumerable<string> FilterActivitiesWithLessThen5Minutes()
        {
            var fiveMinutes = new TimeSpan(0, 0, 5, 0);

            return
                _monitoredDatas
                    .GroupBy(x => x.ActivityLabel)
                    .Where(x => x.Count(y => y.Duration.CompareTo(fiveMinutes) == -1) >= (x.Count() * 90 / 100))
                    .Select(x => x.Key);
        }

        public async Task ProcessAsync(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            using (var sr = new StreamReader(filename))
            {
                _monitoredDatas = new List<MonitoredData>();

                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    var parts = line.Split('\t').Where(x => !string.IsNullOrEmpty(x?.Trim())).ToList();

                    var modelBuilder = new MonitoredDataModelBuilder();

                    var monitoredData = modelBuilder
                        .BuildWithStartTime(DateTime.Parse(parts[0]))
                        .BuildWithEndTime(DateTime.Parse(parts[1]))
                        .BuildWithActivityLavel(parts[2])
                        .Build();

                    _monitoredDatas.Add(monitoredData);
                }
            }
        }
    }
}

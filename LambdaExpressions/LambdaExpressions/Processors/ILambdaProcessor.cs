using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambdaExpressions.Processors
{
    public interface ILambdaProcessor
    {
        int CountMonitoredDays();

        Dictionary<string, int> CountMonitoredDaysPerActivity();

        IEnumerable<Tuple<DateTime, string, int>> CountPerDayEachActivity();

        Dictionary<string, TimeSpan> CountActivityDuration();

        IEnumerable<string> FilterActivitiesWithLessThen5Minutes();

        Task ProcessAsync(string filename);
    }
}

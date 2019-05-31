using LambdaExpressions.Processors;

namespace LambdaExpressions
{
    public class Program
    {
        private const string FileName = "Activities.txt";

        static void Main(string[] args)
        {
            ILambdaProcessor lambdaProcessor = new LambdaProcessor();

            lambdaProcessor.ProcessAsync(FileName).GetAwaiter().GetResult();

            var activityDuration = lambdaProcessor.CountActivityDuration();

            var monitoredDays = lambdaProcessor.CountMonitoredDays();

            var monitoredDaysPerActivity = lambdaProcessor.CountMonitoredDaysPerActivity();

            var eachActivityPerDay = lambdaProcessor.CountPerDayEachActivity();

            var filteredActivities = lambdaProcessor.FilterActivitiesWithLessThen5Minutes();
        }
    }
}

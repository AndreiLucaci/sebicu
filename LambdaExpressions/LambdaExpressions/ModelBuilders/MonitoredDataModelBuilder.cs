using System;
using LambdaExpressions.Models;

namespace LambdaExpressions.ModelBuilders
{
    public class MonitoredDataModelBuilder
    {
        private readonly MonitoredData _modelData;

        public MonitoredDataModelBuilder()
        {
            _modelData = new MonitoredData();
        }

        public MonitoredDataModelBuilder BuildWithActivityLavel(string activityLabel)
        {
            if (!string.IsNullOrEmpty(activityLabel))
            {
                _modelData.ActivityLabel = activityLabel;
            }

            return this;
        }

        public MonitoredDataModelBuilder BuildWithStartTime(DateTime startTime)
        {
            _modelData.StartTime = startTime;

            return this;
        }

        public MonitoredDataModelBuilder BuildWithEndTime(DateTime endTime)
        {
            _modelData.EndTime = endTime;

            return this;
        }

        public MonitoredData Build()
        {
            return _modelData;
        }
    }
}

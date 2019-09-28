using Hangfire;
using HavingFun.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HavingFun.Apps.JobScheduler
{
    public class JobRegistrator
    {
        private LoggerHelper _logger;

        public JobRegistrator(LoggerHelper logger)
        {
            _logger = logger;
        }

        public void RegisterJobs()
        {
            RegisterJob("TestJob", () => _logger.Info("Test job executed"), Cron.Minutely());
        }

        /// <summary>
        /// Rejestracja zadania
        /// </summary>
        /// <param name="name">Nazwa zadania</param>
        /// <param name="jobCall">Metoda uruchamiająca zadanie</param>
        /// <param name="cronExpression">Wyrażenie CRON</param>
        public void RegisterJob(string name, Expression<Action> jobCall, string cronExpression)
        {
            if (!JobConfigs.IsDisabled(cronExpression))
            {
                if (!JobConfigs.IsOneTime(cronExpression))
                {
                    _logger.Info($"Registering job {name}. CronExpression: {cronExpression}");

                    RecurringJob.AddOrUpdate(name, jobCall, cronExpression);

                    _logger.Info($"Registering job {name}. Success.");
                }
                else
                {
                    RegisterOneTimeJob(name, jobCall);
                }
            }
        }

        private void RegisterOneTimeJob(string jobName, Expression<Action> jobCall)
        {
            _logger.Info($"Registering one time job {jobName}. This is a one time job.");

            BackgroundJob.Enqueue(jobCall);

            _logger.Info($"Registering job {jobName}. Success.");
        }
    }
}

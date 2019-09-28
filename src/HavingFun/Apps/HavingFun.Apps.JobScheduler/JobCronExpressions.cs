using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HavingFun.Apps.JobScheduler
{
    public class JobConfigs
    { 
        public JobConfig TestJob { get; set; }

        /// <summary>
        /// Czy zadanie jest wyłączono?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDisabled(string s)
        {
            return string.IsNullOrWhiteSpace(s) || s.ToLower() == "disabled";
        }

        /// <summary>
        /// Czy zadanie jest zadeklarowane jako jednorazowe?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsOneTime(string s)
        {
            return s != null && s.ToLower() == "one-time";
        }
    }

    public class JobConfig
    {
        public string CronExpression { get; set; }
    }
}

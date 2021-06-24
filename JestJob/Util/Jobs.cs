using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JestJob.Util
{
    public class Jobs
    {
        
        public Jobs()
        {
            
        }

        [Obsolete]
        public void DoJob()
        {
            AddPerson addPerson = new AddPerson();
            RecurringJob.AddOrUpdate(() => addPerson.Add(), Cron.MinuteInterval(1));
        }
    }
}

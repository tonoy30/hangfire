using System;

namespace Hangfire.Jobs
{
    public class MyJobs
    {
        public void DoJob()
        {
            Console.WriteLine("Docker-compose creates an environment which run multiple images and enables them to communicate with each other");
        }
    }
}

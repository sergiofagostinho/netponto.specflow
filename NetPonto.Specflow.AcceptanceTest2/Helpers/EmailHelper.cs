using System;
using System.Configuration;
using System.IO;

namespace NetPonto.Specflow.AcceptanceTest2.Helpers
{
    public class EmailHelper
    {
        public bool WasSent(DateTime startTime)
        {
            var threshold = TimeSpan.Parse("00:02:00");
            var files = Directory.GetFiles(ConfigurationManager.AppSettings["EmailDirectory"]);
            foreach (var file in files)
            {
                var creationTime = File.GetCreationTime(file);
                if (creationTime >= startTime && creationTime <= startTime + threshold)
                    return true;
            }
            return false;
        }
    }
}

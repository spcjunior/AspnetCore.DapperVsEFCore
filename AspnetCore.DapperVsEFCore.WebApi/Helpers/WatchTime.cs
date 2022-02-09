using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace AspnetCore.DapperVsEFCore.WebApi.Extensions
{
    public static class WatchTime
    {
        public static TResult Start<TResult>(Func<TResult> function, ILogger logger)
        {
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);

            sw.Start();

            var result = function.Invoke();

            sw.Stop();

            logger.LogInformation($"Tempo total: {sw.ElapsedMilliseconds}ms");
            logger.LogInformation($"GC Gen #2 : {GC.CollectionCount(2) - before2}");
            logger.LogInformation($"GC Gen #1 : {GC.CollectionCount(1) - before1}");
            logger.LogInformation($"GC Gen #0 : {GC.CollectionCount(0) - before0}");
            logger.LogInformation("Done!");

            return result;
        }
    }
}

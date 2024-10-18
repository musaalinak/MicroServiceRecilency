using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollyRecilencyPatterns.Helpers
{
    public static class HttpRecilencyHelper
    {
        public static IAsyncPolicy<HttpResponseMessage> CreateRetryPolicy(int retryCount,TimeSpan sleepDuration)
        {
            return HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(retryCount, x =>
            {
                return sleepDuration;

            }, onRetryAsync: async (outcome, timespan, context) =>
            {
               Console.WriteLine($"Istek tekrar deneniyor : { outcome.Exception}");
            });
        }
    }
}

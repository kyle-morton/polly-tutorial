using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;

namespace RequestService.Policies;

public class ClientPolicy
{
    public AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry {get;}
    public AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry {get;}


    public ClientPolicy()
    {
        // If not successful, retry 5 times
        ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
            res => !res.IsSuccessStatusCode
        ).RetryAsync(5);

        // same idea, but wait 3 seconds before each retry
        LinearHttpRetry = Policy.HandleResult<HttpResponseMessage>(
            res => !res.IsSuccessStatusCode
        )
        .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(3));
    }
}

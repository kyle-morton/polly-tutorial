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

    public ClientPolicy()
    {
        // If not successful, retry 5 times
        ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
            res => !res.IsSuccessStatusCode
        ).RetryAsync(5);
    }
}

﻿using GrainInterfaces;
using Microsoft.Extensions.Logging;

namespace Grains
{
    public class HelloGrain(ILogger<HelloGrain> logger) : Grain, IHello
    {
        private readonly ILogger _logger = logger;

        ValueTask<string> IHello.SayHello(string greeting)
        {
            _logger.LogInformation("""
            SayHello message received: greeting = "{Greeting}"
            """,
                greeting);

            return ValueTask.FromResult($"""

            Client said: "{greeting}", so HelloGrain says: Hello!
            """);
        }
    }
}

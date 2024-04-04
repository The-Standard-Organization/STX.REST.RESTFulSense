﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace STX.REST.RESTFulSense.Clients.Brokers.Https
{
    internal partial class HttpBroker
    {
        public ValueTask<HttpResponseMessage> GetStringAsync(
            string relativeUrl) => GetContentAsync(relativeUrl);

        public ValueTask<HttpResponseMessage> GetStringAsync(
            string relativeUrl,
            CancellationToken cancellationToken) =>
                GetContentAsync(relativeUrl, cancellationToken);
    }
}
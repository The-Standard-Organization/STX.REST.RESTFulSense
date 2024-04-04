﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace STX.REST.RESTFulSense.Clients.Brokers.Https
{
    internal partial interface IHttpBroker
    {
        ValueTask<HttpResponseMessage> GetStreamAsync(
            string relativeUrl);

        ValueTask<HttpResponseMessage> GetStreamAsync(
            string relativeUrl,
            CancellationToken cancellationToken);
    }
}
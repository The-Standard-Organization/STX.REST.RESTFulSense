﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;

namespace STX.REST.RESTFulSense.Clients.Models.Services.HttpExchanges
{
    internal class HttpExchangeContent
    {
        public HttpExchangeHeaders Headers { get; init; }
        public Stream StreamContent { get; set; }
    }
}

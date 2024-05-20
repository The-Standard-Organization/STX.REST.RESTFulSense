﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Net.Http.Headers;
using STX.REST.RESTFulSense.Clients.Models.Services.HttpExchanges;
using STX.REST.RESTFulSense.Clients.Models.Services.HttpExchanges.Headers;

namespace STX.REST.RESTFulSense.Clients.Services.Foundations.HttpExchanges
{
    internal partial class HttpExchangeService
    {
        private static void MapToHttpRequestHeaders(
            HttpExchangeRequestHeaders httpExchangeRequestHeaders,
            HttpRequestHeaders httpRequestHeaders)
        {
            if (httpExchangeRequestHeaders is null)
                return;

            httpExchangeRequestHeaders.Accept.Select(header =>
                {
                    var mediaTypeWithQualityHeaderValue =
                        MapToMediaTypeWithQualityHeaderValue(header);
                    
                    httpRequestHeaders.Accept.Add(mediaTypeWithQualityHeaderValue);

                    return header;
                }
            ).ToArray();

            httpExchangeRequestHeaders.AcceptCharset.Select(header =>
            {
                var stringWithQualityHeaderValue =
                    MapToStringWithQualityHeaderValue(header);
                
                httpRequestHeaders.AcceptCharset.Add(stringWithQualityHeaderValue);
                
                return header;
            }).ToArray();
            
            httpExchangeRequestHeaders.AcceptEncoding.Select(header =>
            {
                var stringWithQualityHeaderValue =
                    MapToStringWithQualityHeaderValue(header);
                
                httpRequestHeaders.AcceptEncoding.Add(stringWithQualityHeaderValue);
                
                return header;
            }).ToArray();
            
            httpExchangeRequestHeaders.AcceptLanguage.Select(header =>
            {
                var stringWithQualityHeaderValue =
                    MapToStringWithQualityHeaderValue(header);
                
                httpRequestHeaders.AcceptLanguage.Add(stringWithQualityHeaderValue);
                
                return header;
            }).ToArray();
            
            httpRequestHeaders.Authorization =
                MapToAuthenticationHeaderValue(
                    httpExchangeRequestHeaders.Authorization);

            httpRequestHeaders.ExpectContinue =
                httpExchangeRequestHeaders.ExpectContinue;

            httpRequestHeaders.From =
                httpExchangeRequestHeaders.From;

            httpRequestHeaders.Host =
                httpExchangeRequestHeaders.Host;
            
            // httpExchangeRequestHeaders.IfMatch
            // httpRequestHeaders.IfMatch.

            httpRequestHeaders.IfModifiedSince =
                httpExchangeRequestHeaders.IfModifiedSince;
            
            // httpExchangeRequestHeaders.IfNoneMatch
            // httpRequestHeaders.IfNoneMatch

            httpRequestHeaders.IfRange =
                MapToRangeConditionHeaderValue(
                    httpExchangeRequestHeaders.IfRange);

            httpRequestHeaders.IfUnmodifiedSince =
                httpExchangeRequestHeaders.IfUnmodifiedSince;

            httpRequestHeaders.MaxForwards =
                httpExchangeRequestHeaders.MaxForwards;

            httpRequestHeaders.Protocol =
                httpExchangeRequestHeaders.Protocol;

            httpRequestHeaders.ProxyAuthorization =
                MapToAuthenticationHeaderValue(
                    httpExchangeRequestHeaders.ProxyAuthorization);

            httpRequestHeaders.Range =
                MapToRangeHeaderValue(httpExchangeRequestHeaders.Range);

            httpRequestHeaders.Referrer =
                httpExchangeRequestHeaders.Referrer;

            httpExchangeRequestHeaders.TE.Select(header =>
                {
                    var transferCodingWithQualityHeaderValue =
                        MapToTransferCodingWithQualityHeaderValue(
                            header);
                    
                    httpRequestHeaders.TE.Add(transferCodingWithQualityHeaderValue);

                    return header;
                }
            ).ToArray();
                  
            httpExchangeRequestHeaders.UserAgent.Select(header =>
                {
                    var productInfoHeaderValue =
                        MapToProductInfoHeaderValue(header);
                    
                    httpRequestHeaders.UserAgent.Add(productInfoHeaderValue);

                    return header;
                }
            ).ToArray();

            httpExchangeRequestHeaders.Expect.Select(header =>
            {
                var nameValueWithParametersHeader =
                MapToNameValueWithParametersHeaderValue(header);
                
                httpRequestHeaders.Expect.Add(nameValueWithParametersHeader);
                
                return header;
            }).ToArray();

            httpRequestHeaders.CacheControl =
                MapToCacheControlHeaderValue(
                    httpExchangeRequestHeaders.CacheControl);

            httpExchangeRequestHeaders.Connection.Select(header =>
            {
                httpRequestHeaders.Connection.Add(header);

                return header;
            }).ToArray();

            httpRequestHeaders.ConnectionClose =
                httpExchangeRequestHeaders.ConnectionClose;

            httpRequestHeaders.Date =
                httpExchangeRequestHeaders.Date;

            httpExchangeRequestHeaders.Pragma.Select(header =>
            {
                var nameValueHeaderValue = MapToNameValueHeaderValue(header);
                httpRequestHeaders.Pragma.Add(nameValueHeaderValue);

                return header;
            }).ToArray();

            httpExchangeRequestHeaders.Trailer.Select(header =>
            {
                httpRequestHeaders.Trailer.Add(header);
                
                return header;
            }).ToArray();
            
            
        }

        


        private static HttpExchangeResponseHeaders MapHttpExchangeResponseHeaders(
            HttpResponseHeaders httpResponseHeaders)
        {
            if (httpResponseHeaders is null)
                return null;

            return new HttpExchangeResponseHeaders
            {
                AcceptRanges =
                    MapArray(
                        httpResponseHeaders.AcceptRanges,
                        @string => @string),

                Age = httpResponseHeaders.Age,

                CacheControl =
                    MapToCacheControlHeader(
                        httpResponseHeaders.CacheControl),

                Connection =
                    MapArray(
                        httpResponseHeaders.Connection,
                        @string => @string),

                ConnectionClose = httpResponseHeaders.ConnectionClose,
                Date = httpResponseHeaders.Date,
                ETag = httpResponseHeaders.ETag.ToString(),
                Location = httpResponseHeaders.Location,

                Pragma =
                    MapArray(
                        httpResponseHeaders.Pragma,
                        MapToNameValueHeader),

                ProxyAuthenticate =
                    MapArray(
                        httpResponseHeaders.ProxyAuthenticate,
                        MapToAuthenticationHeader),

                RetryAfter =
                    MapToRetryConditionHeader(
                        httpResponseHeaders.RetryAfter),

                Server =
                    MapArray(
                        httpResponseHeaders.Server,
                        MapToProductInfoHeader),

                Trailer =
                    MapArray(
                        httpResponseHeaders.Trailer,
                        @string => @string),

                TransferEncoding =
                    MapArray(
                        httpResponseHeaders.TransferEncoding,
                        MapToTransferCodingHeader),

                TransferEncodingChunked =
                            httpResponseHeaders.TransferEncodingChunked,

                Upgrade =
                    MapArray(
                        httpResponseHeaders.Upgrade,
                        MapToProductHeader),

                Vary =
                    MapArray(
                        httpResponseHeaders.Vary,
                        @string => @string),

                Via =
                    MapArray(
                        httpResponseHeaders.Via,
                        MapToViaHeader),

                Warning =
                    MapArray(
                        httpResponseHeaders.Warning,
                        MapToWarningHeader),

                WwwAuthenticate =
                    MapArray(
                        httpResponseHeaders.WwwAuthenticate,
                        MapToAuthenticationHeader)
            };
        }

        private static HttpExchangeContentHeaders MapHttpExchangeContentHeaders(
            HttpContentHeaders httpContentHeaders)
        {
            if (httpContentHeaders is null)
                return null;

            return new HttpExchangeContentHeaders
            {
                Allow =
                    MapArray(
                        httpContentHeaders.Allow,
                        @string => @string),

                ContentDisposition =
                    MapToContentDispositionHeader(
                        httpContentHeaders.ContentDisposition),

                ContentEncoding =
                    MapArray(
                        httpContentHeaders.ContentEncoding,
                        @string => @string),

                ContentLanguage =
                    MapArray(
                        httpContentHeaders.ContentLanguage,
                        @string => @string),

                ContentLength = httpContentHeaders.ContentLength,
                ContentLocation = httpContentHeaders.ContentLocation,
                ContentMD5 = httpContentHeaders.ContentMD5,

                ContentRange =
                    MapToContentRangeHeader(
                        httpContentHeaders.ContentRange),

                ContentType =
                    MapToMediaTypeHeader(
                        httpContentHeaders.ContentType),

                Expires = httpContentHeaders.Expires,
                LastModified = httpContentHeaders.LastModified
            };
        }
    }
}

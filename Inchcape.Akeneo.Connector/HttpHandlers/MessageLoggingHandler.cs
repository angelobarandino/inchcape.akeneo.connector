using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Models;

namespace Inchcape.Akeneo.Connector.HttpHandlers
{
    public class MessageLoggingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var startTime = DateTime.Now;

            var response = base.SendAsync(request, cancellationToken);

            response.ContinueWith(responseMessage => LogMessage(startTime, DateTime.Now, request, responseMessage.Result, responseMessage.Exception), cancellationToken);

            return response;
        }

        private void LogMessage(DateTime startTime, DateTime endTime, HttpRequestMessage request, HttpResponseMessage response, Exception exception)
        {
            if (request.RequestUri.AbsoluteUri.Contains("/api/") == false)
            {
                return;
            }
            
            var loggingInfo = new LoggingInfo
            {
                EndTime = endTime,
                StartTime = startTime, 
                Url = request.RequestUri.AbsoluteUri
            };

            request.Content
                .ReadAsByteArrayAsync()
                .ContinueWith(reqContentTask => { loggingInfo.Request = Encoding.UTF8.GetString(reqContentTask.Result); })
                .ContinueWith(_ =>
                {
                    if (exception == null)
                    {
                        response.Content
                            .ReadAsByteArrayAsync()
                            .ContinueWith(respContentTask =>
                            {
                                loggingInfo.Response = Encoding.UTF8.GetString(respContentTask.Result);
                            })
                            .ContinueWith(_ => LogMessage(loggingInfo));
                    }
                    else
                    {
                        loggingInfo.Exception = exception;
                        LogMessage(loggingInfo);                        
                    }
                });
        }

        private static void LogMessage(LoggingInfo loggingInfo)
        {
            // Log data to appropriate storage.
        }
    }
}
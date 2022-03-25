using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Models;
using Microsoft.Extensions.Logging;

namespace Inchcape.Akeneo.Connector.HttpHandlers
{
    public class MessageLoggingHandler : DelegatingHandler
    {
        private readonly ILogger<AkeneoConnector> _logger;

        public MessageLoggingHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AkeneoConnector>();
        }
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

            if (request.Method == HttpMethod.Get)
            {
                loggingInfo.Exception = exception;
                LogMessage(loggingInfo);
            }
            else
            {
                request.Content?
                    .ReadAsByteArrayAsync()
                    .ContinueWith(reqContentTask => { loggingInfo.Request = Encoding.UTF8.GetString(reqContentTask.Result); })
                    .ContinueWith(_ =>
                    {
                        loggingInfo.Exception = exception;
                        LogMessage(loggingInfo);       
                    });
            }
        }

        private void LogMessage(LoggingInfo info)
        {
            // if (info == null) return;
            //
            // _logger.LogInformation("{Url}", info.Url);
        }
    }
}
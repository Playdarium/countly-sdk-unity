using System;
using System.Threading.Tasks;
using Plugins.Countly.Helpers;
using Plugins.Countly.Models;

namespace Plugins.Countly.Services.Impls.Actual
{
    public class InitializationCountlyService : IInitializationCountlyService
    {
        private readonly SessionCountlyService _sessionCountlyService;

        public InitializationCountlyService(SessionCountlyService sessionCountlyService)
        {
            _sessionCountlyService = sessionCountlyService;
        }

        public string ServerUrl { get; private set; }
        public string AppKey { get; private set; }

        /// <summary>
        ///     Initializes countly instance
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="appKey"></param>
        /// <param name="deviceId"></param>
        public void Begin(string serverUrl, string appKey)
        {
            ServerUrl = serverUrl;
            AppKey = appKey;

            if (string.IsNullOrEmpty(ServerUrl))
                throw new ArgumentNullException(serverUrl, "Server URL is required.");
            if (string.IsNullOrEmpty(AppKey))
                throw new ArgumentNullException(appKey, "App Key is required.");


            //ConsentGranted = consentGranted;
        }

        /// <summary>
        ///     Initializes the Countly SDK with default values
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="enablePost"></param>
        /// <param name="enableConsoleErrorLogging"></param>
        /// <param name="ignoreSessionCooldown"></param>
        /// <returns></returns>
        public async Task<CountlyResponse> SetDefaults(CountlyConfigModel configModel)
        {
            if (!configModel.EnableManualSessionHandling)
            {
                //Start Session and enable push notification
                var result = await _sessionCountlyService.BeginSessionAsync();
//                if (!result.IsSuccess) Debug.LogError("BeginSessionAsync error: " + result);
            }

            return new CountlyResponse
            {
                IsSuccess = true
            };
        }


        /// <summary>
        ///     Gets the base url to make requests to the Countly server.
        /// </summary>
        /// <returns></returns>
        public string GetBaseUrl()
        {
            return string.Format(ServerUrl[ServerUrl.Length - 1] == '/' ? "{0}i?" : "{0}/i?", ServerUrl);
        }
    }
}
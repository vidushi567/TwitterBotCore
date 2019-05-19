using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;

namespace TwitterBotCore.TwitterServices
{
    public enum RequestMethod { GET, POST };

    public class OAuthHelper
    {

        private HMACSHA1 sigHasher;

        private DateTime EpochUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private string TwitterHandle;

        private Dictionary<string, string> Parameters;

        private Dictionary<string, string> QueryParams;

        private RequestMethod HttpMethod;

        private string FQUri;

        public OAuthHelper()
        {

        }
        public OAuthHelper(TwitterRequestObject requestObject)
        {
            HttpMethod = requestObject.HttpRequestType;
            TwitterHandle = requestObject.TwitterHandle;
            sigHasher = new HMACSHA1(new ASCIIEncoding().GetBytes(string.Format("{0}&{1}", requestObject.ConsumerKeySecret, requestObject.AccessTokenSecret)));
            FQUri = requestObject.Url;
            QueryParams = requestObject.QueryStringParams;
            Parameters = new Dictionary<string, string>();
            foreach(var kvp in QueryParams)
            {
                Parameters.Add(kvp.Key, kvp.Value);
            }

            Parameters.Add("oauth_consumer_key", requestObject.ConsumerKey);
            Parameters.Add("oauth_token", requestObject.AccessToken);
            Parameters.Add("oauth_signature_method", "HMAC-SHA1");
            Parameters.Add("oauth_timestamp", string.Empty);
            Parameters.Add("oauth_nonce", string.Empty);
            Parameters.Add("oauth_version", "1.0");
        }


        public string GenerateSignature()
        {
            var sigString = string.Join(
                "&",
                Parameters
                    .Union(Parameters)
                    .Select(kvp => string.Format("{0}={1}", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
                    .OrderBy(s => s)
            );

            var fullSigData = string.Format(
                "{0}&{1}&{2}",
                HttpMethod,
                Uri.EscapeDataString(FQUri),
                Uri.EscapeDataString(sigString)
            );

            return Convert.ToBase64String(sigHasher.ComputeHash(new ASCIIEncoding().GetBytes(fullSigData)));
        }

        public string PostOAuthHeaders()
        {
            var timestamp = (int)((DateTime.UtcNow - EpochUtc).TotalSeconds);
            Parameters["oauth_timestamp"] = timestamp.ToString();
            Parameters["oauth_nonce"] = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            Parameters["oauth_signature"] = GenerateSignature();

            return "OAuth " + string.Join(
                    ", ",
                    Parameters
                        .Where(kvp => kvp.Key.StartsWith("oauth_", StringComparison.CurrentCulture))
                        .Select(kvp => string.Format("{0}=\"{1}\"", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
                        .OrderBy(s => s)
                );
        }

        public string GenerateGetUrl()
        {
            if (HttpMethod == RequestMethod.GET)
            {
                var timestamp = (int)((DateTime.UtcNow - EpochUtc).TotalSeconds);
                Parameters["oauth_timestamp"] = timestamp.ToString();
                Parameters["oauth_nonce"] = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
                Parameters["oauth_signature"] = GenerateSignature();

                FQUri += "?"+string.Join('&', Parameters.Where(x => x.Key.StartsWith("oauth_", StringComparison.CurrentCulture)).Select(kvp => string.Format("{0}={1}",
                    Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value))).OrderBy(s=>s));
                foreach(var kvp in QueryParams)
                {
                    FQUri += "&" + kvp.Key + "=" + Uri.EscapeDataString(kvp.Value);
                }

                return FQUri;

            }
            throw new Exception("OAuth headers can be used for POST method only");
        }

    }
}

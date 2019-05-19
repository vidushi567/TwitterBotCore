using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using TwitterBotCore.HttpRequestProxy;
using TwitterBotCore.TwitterServices;

namespace TwitterBotCore.RequestHelpers
{
    public class PostRequestHelper : RequestHelperBase
    {
        public PostRequestHelper(RequestHelperDetails requestHelperObject):base(requestHelperObject)
        {
        }
        public override string SubmitRequest()
        {
            var oAuthHelper = new OAuthHelper(RequestObject);

            var oAuthHeader = oAuthHelper.PostOAuthHeaders();

            var formData = new FormUrlEncodedContent(RequestHelperDetailsObject.RequestParamters.Where(kvp => !kvp.Key.StartsWith("oauth_")));

            var result = PostRequest.SendRequest(RequestHelperDetailsObject.RequestUrl, oAuthHeader, formData);

            return result;
        }
    }
}

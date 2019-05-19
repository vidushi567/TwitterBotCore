using TwitterBotCore.HttpRequestProxy;
using TwitterBotCore.TwitterServices;

namespace TwitterBotCore.RequestHelpers
{
    public class GetRequestHelper:RequestHelperBase
    {
        public GetRequestHelper(RequestHelperDetails requestHelperDetails) : base(requestHelperDetails)
        {
        }
        public override string SubmitRequest()
        {
            if (RequestHelperDetailsObject.TwitterHandle != null)
                RequestObject.TwitterHandle = RequestHelperDetailsObject.TwitterHandle;

            var oAuthHelper = new OAuthHelper(RequestObject);

            var FQUrl = oAuthHelper.GenerateGetUrl();

            Logging.Log4NetLogger.Instance.Log(FQUrl);

            var result = GetRequest.SendRequest(FQUrl);

            return result;
        }
    }
}

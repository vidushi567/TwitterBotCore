using System;
using System.Configuration;
using TwitterBotCore.TwitterServices;

namespace TwitterBotCore.RequestHelpers
{
    public abstract class RequestHelperBase
    {
        protected RequestHelperDetails RequestHelperDetailsObject;

        protected TwitterRequestObject RequestObject;

        protected RequestHelperBase(RequestHelperDetails requestHelperObject)
        {
            RequestHelperDetailsObject = requestHelperObject;
            RequestObject = new TwitterRequestObject
            {
                ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"],
                ConsumerKeySecret = ConfigurationManager.AppSettings["ConsumerKeySecret"],
                AccessToken = ConfigurationManager.AppSettings["AccessToken"],
                AccessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"],
                QueryStringParams = RequestHelperDetailsObject.RequestParamters,
                HttpRequestType = RequestHelperDetailsObject.HttpRequestMethod,
                Url = RequestHelperDetailsObject.RequestUrl
            };
        }
        public abstract string SubmitRequest();
    }

    public static class RequestHelperFactory
    {
        public static RequestHelperBase CreateRequestHelper(RequestHelperDetails requestHelperObject)
        {
            switch(requestHelperObject.HttpRequestMethod)
            {
                case RequestMethod.GET: return new GetRequestHelper(requestHelperObject);
                case RequestMethod.POST: return new PostRequestHelper(requestHelperObject);
                default: throw new Exception("Please provide a request method type");
            }
        }
    }

}

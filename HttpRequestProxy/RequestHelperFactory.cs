using System;
namespace ReadTweetsPosts.HttpRequestProxy
{

    public static class RequestHelperFactory
    {
        /*
            private RequestHelperFactory()
            {
            }
        */ 
            
        public static IRequestInterface CreateRequest(RequestMethod requestMethod)
        {
            switch(requestMethod)
            {
                case RequestMethod.GET:
                    return new GetRequest();
                case RequestMethod.POST:
                    return new PostRequest();
                default: throw new Exception("Invalid request method type");
            }
        }
    }
}

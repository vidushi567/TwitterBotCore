using System;
using System.Configuration;
using TwitterBotCore.HttpRequestProxy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitterBotCore.LanguageHelpers
{
    public static class TranslationService
    {
        public static string GetTranslation(string fromLang,string toLang,string text)
        {
            var url = ConfigurationManager.AppSettings["TranslateUrl"];

            var fQUri = string.Format(url, fromLang, toLang, text);

            var translatedText = GetRequest.SendRequest(fQUri);

            var arr = JArray.Parse(translatedText);

            return arr[0][0][0].ToString();
        }
    }
}

using System;
using System.Collections.Generic;
namespace TwitterBotCore.LanguageHelpers
{
    public static class LangMapHelper
    {
        private static Dictionary<string, string> _langMap;
        public static Dictionary<string, string> LangMap
        {
            get
            {
                if (_langMap != null && _langMap.Count > 0)
                    return _langMap;
                _langMap = new Dictionary<string, string>
                {
                    {"Afrikaans","af"},
                    {"Irish","ga"},
                    {"Albanian","sq"},
                    {"Italian","it"},
                    {"Arabic","ar"},
                    {"Japanese","ja"},
                    {"Azerbaijani","az"},
                    {"Kannada","kn"},
                    {"Basque","eu"},
                    {"Korean","ko"},
                    {"Bengali","bn"},
                    {"Latin","la"},
                    {"Belarusian","be"},
                    {"Latvian","lv"},
                    {"Bulgarian","bg"},
                    {"Lithuanian","lt"},
                    {"Catalan","ca"},
                    {"Macedonian","mk"},
                    {"Chinese Simplified","zh-CN"},
                    {"Malay","ms"},
                    {"Chinese Traditional","zh-TW"},
                    {"Maltese","mt"},
                    {"Croatian","hr"},
                    {"Norwegian","no"},
                    {"Czech","cs"},
                    {"Persian","fa"},
                    {"Danish","da"},
                    {"Polish","pl"},
                    {"Dutch","nl"},
                    {"Portuguese","pt"},
                    {"English","en"},
                    {"Romanian","ro"},
                    {"Esperanto","eo"},
                    {"Russian","ru"},
                    {"Estonian","et"},
                    {"Serbian","sr"},
                    {"Filipino","tl"},
                    {"Slovak","sk"},
                    {"Finnish","fi"},
                    {"Slovenia","sl"},
                    {"French","fr"},
                    {"Spanish","es"},
                    {"Galician","gl"},
                    {"Swahili","sw"},
                    {"Georgian","ka"},
                    {"Swedish","sv"},
                    {"German","de"},
                    {"Tamil","ta"},
                    {"Greek","el"},
                    {"Telugu","te"},
                    {"Gujarati","gu"},
                    {"Thai","th"},
                    {"Haitian Creole","ht"},
                    {"Turkish","tr"},
                    {"Hebrew","iw"},
                    {"Ukrainian","uk"},
                    {"Hindi","hi"},
                    {"Urdu","ur"},
                    {"Hungarian","hu"},
                    {"Vietnamese","vi"},
                    {"Icelandic","is"},
                    {"Welsh","cy"},
                    {"Indonesian","id"},
                    {"Yiddish","yi"}
                };
                return _langMap;
            }
        }
    }
}

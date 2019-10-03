using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;


namespace Jokes.Controllers
{
    public class JokeService : Joke
    {
        private readonly string url = "https://icanhazdadjoke.com/";
        private string valJoke;

        public string GetRandJokes()
        {
            var service = new WebClient();

            //Json
            service.Headers.Add("Accept", "application/json");
            var jsonJoke = service.DownloadString(url);
            var obj = JObject.Parse(jsonJoke);
            valJoke = obj["joke"].ToString();
            return valJoke;
        }

        public string SearchCore(string Term)
        {
            var service = new WebClient();

            service.Headers.Add("Accept", "application/json");
            var jsonJoke = service.DownloadString(url + "search?term=" + Term + "&limit=30");
            valJoke = Convert.ToString(jsonJoke);
            return valJoke;
        }

        public static int CountWords(string word)
        {
            int count = 0;

            if (word != null)
                count = word.Split().Length;

            return count;
        }

        public string SearchResults(string word)
        {
            string data;
            string textHTML;
            List<Joke> listJokes = new List<Joke>();
            string valReplace, textShort="", textMedium="", textLong="";
            string val;
            int countShort = 0, countMedium = 0, countLarge = 0;
            Int32 jokeLenght;

            try
            {
                data = SearchCore(word);
                var Obj = JObject.Parse(data);


                foreach (var child in Obj["results"])
                {
                    listJokes.Add(new Joke() { StrJoke = child["joke"].ToString() });
                }

                foreach (Joke value in ListJokes)
                {
                    val = value.StrJoke;
                    jokeLenght = CountWords(val);
                    valReplace = string.Format("<strong> {0} </strong>", Regex.Replace(val, word, word.ToUpper(), RegexOptions.IgnoreCase));
                    if (jokeLenght > 1 && jokeLenght < 10)
                    {
                        textShort += string.Format("<li>{0}</li>", valReplace);
                        countShort++;
                    }

                    if (jokeLenght >= 10 && jokeLenght < 20)
                    {
                        textMedium+= string.Format("<li>{0}</li>", valReplace);
                        countMedium++;
                    }

                    if (jokeLenght >= 20)
                    {
                        textLong += string.Format("<li>{0}</li>", valReplace);
                        countLarge++;
                    }
                }
                textHTML = string.Format("<h3>Short Jokes (Total:{0})</h3><ul>{1}</ul><h3>Medium Jokes (Total:{2})</h3><ul>{3}" +
                                         "</ul><h3>Long Jokes (Total:{4})</h3><ul>{5}</ul>", countShort, textShort, countMedium, textMedium, countLarge, textLong);
                return textHTML;
            }
            catch (Exception)
            {
                return "<h3>Search error, please try again later<h3>";
            }
        }
    }


}
using System.Web.Mvc;

namespace Jokes.Controllers
{
    public class HomeController : Controller
    {
        readonly JokeService contJoke = new JokeService();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult RandomJokes()
        {

            return View();
        }

        public string GetRandJokes()
        {
            string data;
           
            data = contJoke.GetRandJokes();
            return data;
        }

        [HttpPost]
        public ActionResult Search(string word)
        {
            string data;
            data = contJoke.SearchResults(word);
            ViewBag.Message = MvcHtmlString.Create(data ?? string.Empty);
            return View();
        }


    }
}
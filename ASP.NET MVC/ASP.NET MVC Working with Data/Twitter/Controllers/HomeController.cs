using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;
using Twitter.ViewModels;

namespace Twitter.Controllers
{
    public class HomeController : Controller
    {
        private IUowData db = new UowData();
        public ActionResult Index()
        {
            var tweets = db.Tweets.All().ToList().Select(tweet => new TweetViewModel
                {
                    TweetId = tweet.TweetId,
                    Author = tweet.Author.UserName,
                    Content = tweet.Content,
                    CretedOn = tweet.CretedOn,
                    Tags = Regex.Matches(tweet.Content, @"(?:^|\s+)(#\w+)")
                        .Cast<Match>()
                        .Select(m => m.Groups[0].Value.Trim())
                        .ToList()
                });

            return View(tweets);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;
using Twitter.ViewModels;
using System.Web.Caching;
using Microsoft.AspNet.Identity;

namespace Twitter.Controllers
{
    [ValidateInput(false)]
    public class TweetsController : Controller
    {
        private IUowData db = new UowData();
        public ActionResult Search(string query)
        {
            if (query == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var cachedTweets = HttpContext.Cache.Get(query) as IEnumerable<TweetViewModel>;
            if (cachedTweets == null)
            {
                cachedTweets = db.Tweets.All().ToList().Where(tweet => tweet.Content.Contains(query)).Select(tweet => new TweetViewModel
                    {
                        TweetId = tweet.TweetId,
                        Author = tweet.Author.UserName,
                        Content = tweet.Content,
                        CretedOn = tweet.CretedOn,
                        Tags = Regex.Matches(tweet.Content, @"(?:^|\s+)(#\w+)")
                            .Cast<Match>()
                            .Select(m => m.Groups[0].Value)
                            .ToList()
                    });

                HttpContext.Cache.Add(query, cachedTweets, null, DateTime.Now.AddMinutes(15), TimeSpan.Zero, CacheItemPriority.Default, null);
            }

            return View(cachedTweets);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View(new TweetViewModel());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(TweetViewModel tweet)
        {
            if (tweet != null)
            {
                var tweetToAdd = new Tweet
                {
                    AuhorId = User.Identity.GetUserId(),
                    Content = tweet.Content,
                    CretedOn = DateTime.Now,
                };

                db.Tweets.Add(tweetToAdd);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
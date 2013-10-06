using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.ViewModels;
using Twitter.Models;
using Microsoft.AspNet.Identity;

namespace Twitter.Areas.Administration
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    [ValidateInput(false)]
    public class TweetsAdministrationController : Controller
    {
        private IUowData db = new UowData();
        //
        // GET: /Administration/Tweets/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.Tweets.All().Select(tweet => new EditableTweetViewModel
            {
                TweetId = tweet.TweetId,
                Content = tweet.Content,
            }).ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, EditableTweetViewModel tweet)
        {
            if (tweet != null && ModelState.IsValid)
            {
                Tweet t = new Tweet
                {
                    Content = tweet.Content,
                    AuhorId = User.Identity.GetUserId(),
                    CretedOn = DateTime.Now
                };

                db.Tweets.Add(t);
                db.SaveChanges();
            }

            return Json(new[] { tweet }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, EditableTweetViewModel tweet)
        {
            if (tweet != null && ModelState.IsValid)
            {
                var target = db.Tweets.GetById(tweet.TweetId);
                if (target != null)
                {
                    target.Content = tweet.Content;
                    db.Tweets.Update(target);
                    db.SaveChanges();
                }
            }

            return Json(new[] { tweet }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, EditableTweetViewModel tweet)
        {
            if (tweet != null)
            {
                db.Tweets.Delete(tweet.TweetId);
                db.SaveChanges();
            }

            return Json(new[] { tweet }.ToDataSourceResult(request, ModelState));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CodeJewels.Models;
using CodeJewels.Data;
using CodeJewels.Repositories;

namespace CodeJewels.Services.Controllers
{
    public class VotesController : ApiController
    {
        private const int NEGATIVE_VOTES_TO_DELETE = -1;
        private CodeJewelDataContext context;

        public VotesController()
        {
            this.context = new CodeJewelDataContext();
        }

        // POST api/Votes
        [ActionName("addvote")]
        public HttpResponseMessage PostVote(int id, [FromBody]bool vote)
        {
            if (ModelState.IsValid)
            {
                var jewel = this.context.CodeJewels.FirstOrDefault(x => x.CodeJewelId == id);
                if (jewel == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState);
                }

                jewel.Votes.Add(new Vote { Value = vote, CodeJewelId = id });
                if (vote == true)
                {
                    jewel.Rating++;
                }
                else
                {
                    jewel.Rating--;
                }

                context.SaveChanges();
                CheckForNegativeRating(jewel);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, vote);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = jewel.CodeJewelId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        private void CheckForNegativeRating(CodeJewel jewel)
        {
            if (jewel.Rating <= NEGATIVE_VOTES_TO_DELETE)
            {
                context.CodeJewels.Remove(jewel);
                context.SaveChanges();
            }
        }
    }
}
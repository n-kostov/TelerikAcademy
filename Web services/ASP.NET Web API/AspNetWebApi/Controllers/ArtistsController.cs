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
using AspNetWebApi.Models;
using ArtistsAlbums.Model;

namespace AspNetWebApi.Controllers
{
    public class ArtistsController : ApiController
    {
        private MusicDBEntities db = new MusicDBEntities();

        // GET api/Artists
        public IEnumerable<ArtistModel> GetArtists()
        {
            var artists = db.Artists.Include("Songs").Include("Albums").Select(ArtistModel.FromArtist);
            return artists.AsEnumerable();
        }

        // GET api/Artists/5
        public ArtistModel GetArtist(int id)
        {
            ArtistModel artist = db.Artists.Where(x => x.ArtistId == id).Select(ArtistModel.FromArtist).FirstOrDefault();
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artist;
        }

        public IEnumerable<ArtistModel> GetArtistsByCountry(string country)
        {
            var artists = db.Artists.Where(x => x.Country == country).Select(ArtistModel.FromArtist);

            if (artists == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artists;
        }

        public IEnumerable<ArtistModel> GetArtistsByName(string name)
        {
            var artists = db.Artists.Where(x => x.Name == name).Select(ArtistModel.FromArtist);

            if (artists == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artists;
        }

        public IEnumerable<ArtistModel> GetArtistsBySong(string songName)
        {
            var artists = db.Artists.Include("Songs").Where(x => x.Songs.Any(y => y.Title == songName))
                .Select(ArtistModel.FromArtist);

            if (artists == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artists;
        }

        // PUT api/Artists/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            if (ModelState.IsValid)
            {
                artist.ArtistId = id;
                db.Entry(artist).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Artists
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.ArtistId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Artists/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Artists.Remove(artist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
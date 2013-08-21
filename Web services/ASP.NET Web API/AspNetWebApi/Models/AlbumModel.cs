using ArtistsAlbums.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace AspNetWebApi.Models
{
    public class AlbumModel
    {
        public AlbumModel()
        {
            this.Songs = new List<SongModel>();
            this.Artists = new List<ArtistModel>();
        }

        public int AlbumId { get; set; }
        public string Title { get; set; }
        public Nullable<DateTime> Year { get; set; }
        public string Producer { get; set; }

        public ICollection<SongModel> Songs { get; set; }
        public ICollection<ArtistModel> Artists { get; set; }
    }
}
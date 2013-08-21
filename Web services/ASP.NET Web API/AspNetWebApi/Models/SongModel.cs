using ArtistsAlbums.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace AspNetWebApi.Models
{
    public class SongModel
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public Nullable<DateTime> Year { get; set; }
        public string Genre { get; set; }

        public ArtistModel Artist { get; set; }
        public AlbumModel Album { get; set; }
    }
}
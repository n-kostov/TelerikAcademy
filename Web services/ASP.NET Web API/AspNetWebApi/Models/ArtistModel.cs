using ArtistsAlbums.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace AspNetWebApi.Models
{
    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return x => new ArtistModel
                {
                    ArtistId = x.ArtistId,
                    Name = x.Name,
                    Country = x.Country,
                    DateOfBirth = x.DateOfBirth,
                    Songs = x.Songs.Select(y =>
                        new SongModel { SongId = y.SongId, Title = y.Title, Genre = y.Genre, Year = y.Year }),
                    Albums = x.Albums.Select(y =>
                        new AlbumModel { AlbumId = y.AlbumId, Title = y.Title, Producer = y.Producer, Year = y.Year })
                };
            }
        }

        public ArtistModel()
        {
            this.Albums = new List<AlbumModel>();
            this.Songs = new List<SongModel>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }
        public IEnumerable<AlbumModel> Albums { get; set; }
    }
}
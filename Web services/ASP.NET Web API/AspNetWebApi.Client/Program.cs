using ArtistsAlbums.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApi.Client
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:8357/") };

        static void Main(string[] args)
        {
            Client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));

            GetArtists("api/artists");

            //AddNewArtist("Artist", "Bulgaria", null, null, null);
            //GetArtists("api/artists");

            UpdateArtist(13, "PEsho");
            GetArtists("api/artists");

            //DeleteArtist(13);
            //GetArtists("api/artists")
        }

        static void GetArtists(string uri)
        {
            HttpResponseMessage response = Client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                var products = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;


                foreach (var p in products)
                {
                    Console.WriteLine("{0,2} {1,-10} {2}", p.ArtistId, p.Name, p.Country);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        static Artist GetArtistById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/artists/").Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result.FirstOrDefault(x => x.ArtistId == id);
                return artist;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        internal static void AddNewArtist(string name, string country, DateTime? dateOfBirth,
            ICollection<Album> albums, ICollection<Song> songs)
        {
            var artist = new Artist
            {
                Name = name,
                Country = country,
                DateOfBirth = dateOfBirth,
                Albums = albums,
                Songs = songs
            };

            var response = Client.PostAsJsonAsync("api/artists", artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateArtist(int id, string name, string country = null, DateTime? dateOfBirth = null,
            ICollection<Album> albums = null, ICollection<Song> songs = null)
        {
            Artist artist = GetArtistById(id);
            if (artist == null)
            {
                throw new ArgumentNullException("artist", "The artist does not exist!");
            }

            artist.Name = name;
            if (country != null)
            {
                artist.Country = country;
            }

            if (dateOfBirth != null)
            {
                artist.DateOfBirth = dateOfBirth;
            }

            if (albums != null)
            {
                artist.Albums = albums;
            }

            if (songs != null)
            {
                artist.Songs = songs;
            }

            var response = Client.PutAsJsonAsync("api/artists/" + id, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist {0} updated!", id);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        static void DeleteArtist(int id)
        {
            var response = Client.DeleteAsync("api/artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}

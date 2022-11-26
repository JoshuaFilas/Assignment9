using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace RestfulTheater.Models
{
    public class ShowTimes
    {
        //HttpClient that will be used to call the movie api
        HttpClient client = new HttpClient();
        //The urlBase for the movie api - will add in the parameters as needed
        string urlBase = "https://flixster.p.rapidapi.com/theaters/detail?id=";
        //This were the result from the API called is placed
        private string result;
        //This is the object used to return data back to the user
        public List<MoviesWithShowtimes> list = new List<MoviesWithShowtimes>();

        //Constructor that takes in the theater code that can be obtained using the other
        //theater service to get showtimes for current films
        public ShowTimes(string theaterCode)
        {
            list = getShowTimes(theaterCode);
        }

        //This function gets all showtimes for a certian theater
        private List<MoviesWithShowtimes> getShowTimes(string theaterCode)
        {
            string url = urlBase + theaterCode;
            callShowTimeAPI(url);
            return getAllTimes();
        }

        //This is used to actually parse the data supplied by the theater API
        //It puts the theater and its general information as well as all showtimes
        //Into new objects that are then returned through the public list above
        private List<MoviesWithShowtimes> getAllTimes()
        {
            List<Movie> movies = new List<Movie>();
            ShowTimeRoot deserialized = new JavaScriptSerializer().Deserialize<ShowTimeRoot>(result);
            foreach(Movie movie in deserialized.data.theaterShowtimeGroupings.movies)
            {
               movies.Add(movie);
            }
            List<MoviesWithShowtimes> moviesWithShowtimes = new List<MoviesWithShowtimes>(movies.Count);
            for(int i = 0; i < movies.Count; ++i)
            {
                moviesWithShowtimes.Add(new MoviesWithShowtimes(movies[i], movies[i].movieVariants[0].amenityGroups[0].showtimes));                
            }
            return moviesWithShowtimes;
        }

        //This is where the Movie API is called with the theater code parameter added to the base and passed in.
        //The result of the API call is placed in the result variable above
        private void callShowTimeAPI(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Key", "5d51dcd53bmshdc1fcffcaffa674p178d8cjsn12acbd78933a");
            request.Headers.Add("X-RapidAPI-Host", "flixster.p.rapidapi.com");
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.StatusCode.ToString());
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader read = new StreamReader(responseStream))
                        {
                            result = read.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

    //The object used to return data to the user
    public class MoviesWithShowtimes
    {
        public MoviesWithShowtimes() { }
        public MoviesWithShowtimes(Movie movie, List<Showtime> showtimes)
        {
            name = movie.name;
            emsId = movie.emsId;
            emsVersionId = movie.emsVersionId;
            fandangoId = movie.fandangoId;
            durationMinutes = movie.durationMinutes;
            releaseDate = movie.releaseDate;
            this.showtimes = showtimes;
        }
        public string fandangoId { get; set; }
        public string emsId { get; set; }
        public string emsVersionId { get; set; }
        public string name { get; set; }
        public int durationMinutes { get; set; }
        public string releaseDate { get; set; }
        public List<Showtime> showtimes { get; set; }
    }

    //Classes used to deseialize the result from the API
    public class AmenityGroup
    {
        public List<Showtime> showtimes { get; set; }
    }

    public class showTimeData
    {
        public TheaterShowtimeGroupings theaterShowtimeGroupings { get; set; }
    }

    public class MotionPictureRating
    {
        public string code { get; set; }
        public string description { get; set; }
    }
    public class Movie
    {
        public string fandangoId { get; set; }
        public string emsId { get; set; }
        public string emsVersionId { get; set; }
        public string name { get; set; }
        public int durationMinutes { get; set; }
        public string releaseDate { get; set; }
        public List<MovieVariant> movieVariants { get; set; }
    }
    public class MovieVariant
    {
        public List<AmenityGroup> amenityGroups { get; set; }
    }
    public class ShowTimeRoot
    {
        public showTimeData data { get; set; }
    }
    public class Showtime
    {
        public string id { get; set; }
        public string type { get; set; }
        public string providerTime { get; set; }
        public string providerDate { get; set; }
        public string isActive { get; set; }
        public string sdate { get; set; }
    }

    public class TheaterShowtimeGroupings
    {
        public string theaterId { get; set; }
        public List<string> displayDates { get; set; }
        public string displayDate { get; set; }
        public List<Movie> movies { get; set; }
    }
}
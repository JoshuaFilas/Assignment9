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
    public class Theater
    {
        //Setup for calling the Theater API
        HttpClient client = new HttpClient();
        string urlBase = "https://flixster.p.rapidapi.com/theaters/list";

        //Used to store the result of the Theater API call
        private string result;
        //Used to return the information back to the user
        public List<Theaters> list = new List<Theaters>();

        //Gets theaters based on no information - can be use to generally get current shows in theaters - otherwise not super useful
        public Theater()
        {
            getTheaters();
            list = buildTheaterList();
        }

        //Returns theaters based on zipCode
        //If showTimes is true then it will only get theaters with showtime info populated
        public Theater(int zipCode, string showTimes, int distance = 10)
        {
            getTheaters(zipCode, distance);
            List<Theaters> result = buildTheaterList();
            if (showTimes.Equals("true"))
            {
                foreach(Theaters theater in result)
                {
                    if (theater.hasShowtimes.Equals("true"))
                    {
                        list.Add(theater);
                    }
                }
            }
            else
            {
                list = result;
            }
        }

        //Returns theaters based on longitude and latitude
        //If showTimes is true it will only report theaters with showtimes populated
        public Theater(decimal longitude, decimal latitude, string showTimes, int distance = 10)
        {
            getTheaters(longitude, latitude, distance);            
            List<Theaters> result = buildTheaterList();
            if (showTimes.Equals("true"))
            {
                foreach (Theaters theater in result)
                {
                    if (theater.hasShowtimes.Equals("true"))
                    {
                        list.Add(theater);
                    }
                }
            }
            else
            {
                list = result;
            }
        }

        //pull a list of every theater
        private void getTheaters()
        {
            string url = "https://flixster.p.rapidapi.com/theaters/list";
            callTheaterAPI(url);            
        }

        //allows the user to input their zipCode to find theaters, They can also put in a distance if they wish.
        //However if they do not input one a defualt value is used instead.
        private void getTheaters(int zipCode, int distance)
        {
            string url = urlBase + "?zipCode=" + zipCode.ToString() + "&radius=" + distance.ToString();
            callTheaterAPI(url);
        }
        //Allows the user to input long and lat to find theaters, They can also put in a distance if they wish.
        //However if you do not input one a defualt value is used instead.
        private void getTheaters(decimal longitude, decimal latitude, int distance)
        {
            string url = urlBase + "?latitude=" + latitude.ToString() + "&longitude=" + longitude.ToString() + "&radius=" + distance.ToString();
            callTheaterAPI(url);
        }

        //Calls the Theater API and puts the result in result
        private void callTheaterAPI(string url)
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

        //Used to build the list of theaters that is sent to the caller
        private List<Theaters> buildTheaterList()
        {
            List<Theaters> theater = new List<Theaters>();
            Root deserialized = new JavaScriptSerializer().Deserialize<Root>(result);
            foreach (Theaters building in deserialized.data.theaters)
            {
                theater.Add(building);
            }
            return theater;
        }
    }

    //Classes used to deserialize the API result
    public class Data
    {
        public List<Theaters> theaters { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
    }

    public class Theaters
    {
        public string id { get; set; }
        public string tid { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string hasShowtimes { get; set; }
        public bool hasReservedSeating { get; set; }
        public bool isTicketing { get; set; }
        public double distance { get; set; }
    }
}
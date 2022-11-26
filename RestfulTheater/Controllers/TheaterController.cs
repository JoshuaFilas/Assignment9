using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestfulTheater.Models;
namespace RestfulTheater.Controllers
{
    public class TheaterController : ApiController
    {
        //Returns a mashup of theaters -- not really usefull unless you travel way to much
        [HttpGet]
        public List<Theaters> Get()
        {
            Theater theater = new Theater();
            return theater.list;
        }

        //Returns a list of theaters based on a zipCode 
        //User can chose to specify if that theater has to have showtimes or not - default is false
        //A distance of 10 miles around the user will be used unless other wise stated
        [HttpGet]
        public List<Theaters> Get(int zipCode, string showTimes = "false", int distance = 10)
        {
            Theater theater = new Theater(zipCode, showTimes, distance);
            return theater.list;
        }

        //Returns  list of theater based on longitude and latitude
        //User can chose to specify if that theater has to have showtimes or not - defualt is false
        //A distance of 10 miles around the user will be used unless other wise stated
        [HttpGet]
        public List<Theaters> Get(decimal longitude,  decimal latitude, string showTimes = "false", int distance = 10)
        {
            Theater theater = new Theater(longitude, latitude, showTimes, distance);
            return theater.list;
        }
    }
}

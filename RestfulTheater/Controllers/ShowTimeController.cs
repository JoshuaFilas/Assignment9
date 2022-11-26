using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestfulTheater.Models;

namespace RestfulTheater.Controllers
{
    public class ShowTimeController : ApiController
    {
        /// <summary>
        /// Gets Showtimes for a movie theater.
        /// </summary>
        /// <param name="theaterID"></param>
        /// <returns>List<MovieWithShowtimes></returns>
        [HttpGet]
        public List<MoviesWithShowtimes> Get(string theaterID)
        {
            ShowTimes showtime = new ShowTimes(theaterID);
            return showtime.list;
        }
    }
}

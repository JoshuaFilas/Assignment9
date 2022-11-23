using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace TryIt
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public partial class WebForm1 : System.Web.UI.Page
    {
        httpVerb httpMethod { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void TheaterSub(object sender, EventArgs e)
        {
            string endpoint = "http://webstrar63.fulton.asu.edu/page1/api/Theater";
            string result = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint);
            request.KeepAlive = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            request.Method = httpMethod.ToString();
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
            List<Root> theaters = new JavaScriptSerializer().Deserialize<List<Root>>(result);
            TheaterTable.Rows.Clear();
            foreach (Root root in theaters)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = "Theater name: " + root.name;
                cell.Text = cell.Text + " Theater ID: " + root.id;
                row.Cells.Add(cell);
                TheaterTable.Rows.Add(row);
            }
        }

        protected void theaterSub1(object sender, EventArgs e)
        {
            TheaterTable.Rows.Clear();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://webstrar63.fulton.asu.edu/page1/api/Theater?zipCode=" + TextBox1.Text + "&showTimes="+TextBox2.Text+"&distance="+ TextBox3.Text);
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            string result = string.Empty;
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
            List<Root> theaters = new JavaScriptSerializer().Deserialize<List<Root>>(result);
            foreach (Root root in theaters)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = "Theater name: " + root.name;
                cell.Text = cell.Text + " Theater ID: " + root.id;
                row.Cells.Add(cell);
                TheaterTable.Rows.Add(row);
            }
        }
        protected void theaterSub2(object sender, EventArgs e)
        {
            TheaterTable.Rows.Clear();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://webstrar63.fulton.asu.edu/page1/api/Theater?longitude="
                + longbox.Text + "&latitude=" + latbox.Text + "&showTimes=" + showtimebox.Text + "&distance=" + distancebox.Text);
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            string result = string.Empty;
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
            List<Root> theaters = new JavaScriptSerializer().Deserialize<List<Root>>(result);
            foreach (Root root in theaters)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = "Theater name: " + root.name;
                cell.Text = cell.Text + " Theater ID: " + root.id;
                row.Cells.Add(cell);
                TheaterTable.Rows.Add(row);
            }
        }
    }
    public class Root
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
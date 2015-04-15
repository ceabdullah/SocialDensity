using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SocialDensity.Controllers
{
    public class CellularDataController : Controller
    {

        public static string opencellidBaseUrl
        {
            get { return ConfigurationManager.AppSettings["opencellidBaseUrl"]; }
        }

        public static string opencellidApiKey
        {
            get { return ConfigurationManager.AppSettings["opencellidApiKey"]; }
        }

        // GET: CellularData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCellsByCoordinate(string minLat, string minLon, string maxLat, string maxLon)
        {
            using (var wb = new WebClient())
            {
                try
                {
                    string response = wb.DownloadString(opencellidBaseUrl + "cell/getInArea" + "?" + "key=" + opencellidApiKey + "&BBOX=" + minLat + "," + minLon + "," + maxLat + "," + maxLon + "&format=json");
                    return Json(response);
                }
                catch (Exception e)
                {
                    return Json("failure");
                }
            }
        }

    }
}
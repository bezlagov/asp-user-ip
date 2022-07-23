using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;
using UserData.Models;


namespace UserData.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string str = "";
            var x = HttpContext.Request;
            foreach (var item in HttpContext.Request.Headers)
            {
                str += item.Key + " / " + item.Value + " \n";
            }

            UserWebData data = new UserWebData()
            {
                Browser = HttpContext.Request.Headers["User-Agent"],
                Ip = GetLocalIPAddress(),/*HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString(),*/
            };

            return View(data);
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "-";
        }
    }
}

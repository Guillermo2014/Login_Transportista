using Logictrack_listado.API;
using Logictrack_listado.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Logictrack_listado.Controllers
{
    public class DespachoController : System.Web.Mvc.Controller
    {
        Backend _api = new Backend();
        // GET: Despacho
        public async Task<System.Web.Mvc.ActionResult> Index()
        {
            List<Despacho> despachos = new List<Despacho>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage response = await client.GetAsync("despachosPorTransportista" + $"/{id}");
            var uri = "despachosPorTransportista/" + HttpContext.Session["IdTransportista"].ToString();
            HttpResponseMessage response = await client.GetAsync(uri);
            //HttpResponseMessage response = await client.GetAsync("despachos");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                despachos = JsonConvert.DeserializeObject<List<Despacho>>(result);
            }
            return View(despachos);
        }
    }
}
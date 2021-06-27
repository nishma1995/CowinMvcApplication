using CowinMvcApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CowinMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index1()
        {
            //var selectList = new List<SelectListItem>();
            List<StateRoot> stateList=new List<StateRoot>();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://cdn-api.co-vin.in/api/v2/admin/location/states").Result;
            var a = response.Content.ReadAsStringAsync().Result;
            StateRoot post = JsonConvert.DeserializeObject<StateRoot>(a);
            //foreach (var state in post.states)
            //{
                //ViewBag.CategoryType.Add(state.state_id + "  " + state.state_name);
                //selectList.Add(new SelectListItem { Text = state.state_id.ToString(), Value = state.state_name });

                stateList.Add(post);
                

            //}
            
            return View(stateList);
        }
    }
}
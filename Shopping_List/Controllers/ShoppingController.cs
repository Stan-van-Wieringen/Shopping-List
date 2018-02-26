using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping_List.Models;

namespace Shopping_List.Controllers
{
    public class ShoppingController : Controller
    {
        private List<Item> items = new List<Item>();

        [HttpGet]
        public ViewResult View()
        {
            if (TempData.Peek("items") != null)
            {
                items = JsonConvert.DeserializeObject<List<Item>>(TempData["items"].ToString());
            }
            return View(items);
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(new Item { });
        }

        [HttpPost]
        public IActionResult Index(Item item)
        {
            items.Add(item);
            TempData["items"] = JsonConvert.SerializeObject(items);
            //TempData.Keep();
            return View("Index", item);
        }
    }
}
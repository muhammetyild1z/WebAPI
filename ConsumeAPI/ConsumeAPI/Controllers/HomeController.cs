﻿using ConsumeAPI.ReponseModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumeAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
           var client= _httpClientFactory.CreateClient();
            var responseMessage= await client.GetAsync("http://localhost:5000/Products");
            if (responseMessage.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
              var result=  JsonConvert.DeserializeObject<List<ProductResponseModel>>(jsonData);
               return View(result);
            }
            else
            {
                return View(null);
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UIForMicro.Models;

namespace UIForMicro.Controllers
{
    public class ProductUIController : Controller
    {
        public IActionResult Index() 
        {
            IEnumerable<ProductUI> productUIList;
            HttpResponseMessage response = GlobalVariables.WebApiClent.GetAsync("Product").Result;
            productUIList = response.Content.ReadAsAsync<IEnumerable<ProductUI>>().Result;
            return View(productUIList);
        }

        public IActionResult AddOrEdit(int id=0)
        {
            if(id==0)
            {
                return View(new ProductUI());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClent.GetAsync("Product/"+id).Result;
                return View(response.Content.ReadAsAsync<ProductUI>().Result);
            }
           
        }

        [HttpPost]
        public IActionResult AddOrEdit(ProductUI productUI)
        {
     
                if (productUI.Id == 0)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClent.PostAsJsonAsync("Product", productUI).Result;
                }
                else
                {

                    var content = new StringContent(JsonConvert.SerializeObject(productUI), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = GlobalVariables.WebApiClent.PutAsJsonAsync
                        ("Product/" + productUI.Id, content).Result;
                    if(response.IsSuccessStatusCode)
                {

                }
                }
                return RedirectToAction("Index");
           
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClent.DeleteAsync("product/"+id).Result;
            return RedirectToAction("Index");

        }

    }

}
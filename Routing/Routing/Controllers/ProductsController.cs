using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public class ProductsController : Controller
    {
        
        public ActionResult Index()
        {

            return View();
        }

        [Route("Products/Details/{id:int?}")]
        public ActionResult Details(int id)
        {

            var Product = new[]
            {
               new  {ProductId=1,ProductName="SGK",price=15000},
               new  {ProductId=2,ProductName="Conan",price=15000},
               new  {ProductId=3,ProductName="Doreamon",price=20000},
               new  {ProductId=4,ProductName="Tamhon",price=30000}

           };
            string proName = "";
            foreach (var product in Product)
            {
                if (product.ProductId == id)
                {
                    proName = product.ProductName;
                }

            }
            ViewBag.ProName = proName;
            return View();
        }
    }
}

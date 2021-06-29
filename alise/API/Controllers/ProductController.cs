using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public string GetProducts(){
            return "Ürünler Listelendi";
        }

        [HttpGet("{id}")]
        public string GetProductById(int id){
            return "Ürün Listelendi id : " + id;
        }
    }
}
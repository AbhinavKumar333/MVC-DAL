using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace UserAPI.Controllers
{
    public class ProductController : ApiController
    {
        UserDAL.CrudRepository repo = null;
        public ProductController()
        {
            repo = new UserDAL.CrudRepository();
        }
        [Route("Product/GetProducts")]
        public JsonResult<List<Models.Product>> GetProducts()
        {
            List<UserDAL.product> dal = repo.GetAllProducts();
            List<Models.Product> api = new List<Models.Product>();
            foreach(var d in dal)
            {
                Models.Product temp = new Models.Product();
                temp.productId = d.productId;
                temp.productname = d.productname;
                temp.productPrice = d.productPrice;
                temp.productType = d.productType;
                temp.productDescription = d.productDescription;
                api.Add(temp);
            }
            return Json<List<Models.Product>>(api);
        }
    }
}

using Categories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Categories.Controllers
{
    public class CategoriesController : ApiController
    {
        private WebOtoCoreEntities1 db = new WebOtoCoreEntities1();
        public IQueryable<ProductCategory> GetProducts()
        {
            return db.ProductCategories;
        }
        [ResponseType(typeof(ProductCategory))]
        public IHttpActionResult GetProduct(Int32 id)
        {
            ProductCategory product = db.ProductCategories.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}

using AnindaKapinda.BusinessLogic.Abstract;
using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnindaKapinda.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        IUrunService _urunService;
        public ProductsController(IUrunService urunService)
        {
            _urunService = urunService;
        }
        public List<Urun> Get()
        {
            return _urunService.GetAll();
        }
    }
}

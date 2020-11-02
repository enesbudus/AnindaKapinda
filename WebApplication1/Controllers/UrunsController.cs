using AnindaKapinda.BusinessLogic.Abstract;
using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class UrunsController : ApiController
    {
        IUrunService _urunService;
        public UrunsController(IUrunService urunService)
        {
            _urunService = urunService;
        }
        public List<Urun> Get()
        {
            return _urunService.GetAll();
        }
        public HttpResponseMessage Get(int id)
        {
            var urun = _urunService.GetByID(id);
            return Request.CreateResponse(HttpStatusCode.OK, urun);
        }
        [HttpPost]
        public IHttpActionResult Post(Urun urun)
        {
            
            _urunService.Add(urun);

            return Ok("Başarılı kayıt");
        }
        //public bool Put(Urun urun)
        //{
        //    return _urunService.Update(urun);
        //}
        //public bool Delete(int id)
        //{
        //    return _urunService.Delete(id);
        //}
    }
}

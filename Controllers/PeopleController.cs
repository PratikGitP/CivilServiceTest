using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApplication1.Mediator;

namespace WebApplication1.Controllers
{
    public class PeopleController : ApiController
    {
        [HttpGet,Route("People/GetByCityRange/{city}/{range}")]
        public IHttpActionResult GetByCityRange(string city,int range)
        {
            try
            {
                PeopleMediator mediator = new PeopleMediator();
                return Ok(mediator.GetByCityRange(city,range));

            }
            catch(Exception ex)
            {
                //Log Execption messaage : ex
                throw;
            }
        }
    }
}

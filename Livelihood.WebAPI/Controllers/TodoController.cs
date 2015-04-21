using Livelihood.Configuration;
using Livelihood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Livelihood.WebAPI.Controllers
{
    public class TodoController : ApiController
    {

        /// <summary>
        /// 基于OData的查询
        /// </summary>
        /// <returns></returns>
        [ODataRoute]
        [EnableQuery]        
        public IHttpActionResult Get()
        {        
            return Ok(ServiceLocator.Query<Todo>());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Study.Business;

namespace Study.API.Controllers
{
    [RoutePrefix("api/group")]
    public class GroupTeamController : ApiController
    {
        // pego a lista dos usuários criados
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(GroupTeamMethods.Display());
        }

        //[HttpGet]
        //[Route("find/{id}")]
        //public 

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(Business.DTO.GroupTeamDTO groupTeam)
        {
            if (groupTeam == null)
            {
                return BadRequest();
            }
            else
            {
                GroupTeamMethods.Create(groupTeam);
                var uri = new Uri("/api/group", UriKind.Relative);
                return Created(uri,201);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Study.Business;
using Study.Business.DTO;

namespace Study.API.Controllers
{
    /// <summary>
    /// Métodos GET, POST, PUT e DELETE para a tabela Group
    /// </summary>
    [RoutePrefix("api/group")]
    public class GroupTeamController : ApiController
    {
        // pego a lista dos grupos criados
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(GroupTeamDTO))]
        public IHttpActionResult Get()
        {
            var groupTeamMethods = new GroupTeamMethods();
            return Ok(groupTeamMethods.Display());
        }

        // pego por grupo por id
        [HttpGet]
        [Route("find/{id}")]
        [ResponseType(typeof(GroupTeamDTO))]
        public IHttpActionResult GetById(int id)
        {
            var groupTeamMethods = new GroupTeamMethods();
            var found = groupTeamMethods.Find(id);
            if (found == null)
            {
                return BadRequest("The item could not be found.");
            }
            else
            {
                return Ok(found);
            }
        }

        // Cria grupo
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(string))]
        public IHttpActionResult Post(GroupTeamDTO groupTeam)
        {
            var groupTeamMethods = new GroupTeamMethods();
            if (groupTeam == null)
            {
                return BadRequest();
            }
            else
            {
                groupTeamMethods.Create(groupTeam);
                var uri = new Uri("/api/group", UriKind.Relative);
                return Created(uri,"Group created with success.");
            }
        }

        // Atualiza grupo
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, GroupTeamDTO groupToUpdate)
        {
            var update = new GroupTeamMethods();
            if (update.Find(id) == null)
            {
                return BadRequest("The item could not be found");
            }
            else
            {
                update.Update(id, groupToUpdate);

#warning Resposta com objeto genérico <T>
                //var result = new HttpResponseMessage<GroupTeamDTO>(null, HttpStatusCode.NotFound);
                
                //var responseMSg =  Request.CreateResponse<GroupTeamDTO>(HttpStatusCode.OK, groupToUpdate);

                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));

                //return ResponseMessage(responseMSg);
            }
        }

        // deleta grupo por id
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var groupTeamMethods = new GroupTeamMethods();
            if (groupTeamMethods.Find(id) == null)
            {
                return BadRequest("The item doesn't exist.");
            }
            else
            {
                groupTeamMethods.Delete(id);
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
        }
    }
}

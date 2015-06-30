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
    /// Métodos GET, POST, PUT e DELETE para a tabela User
    /// </summary>
    [RoutePrefix("api/user")]
    public class UserTeamController : ApiController
    {
        // método get para retornar lista de usuários cadastrados
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(UserTeamDTO))]
        public IHttpActionResult Get()
        {
            return Ok(UserTeamMethods.Display());
        }

        // pega user por id
        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(UserTeamDTO))]
        public IHttpActionResult GetById(int id)
        {
            var found = UserTeamMethods.Find(id);
            if (found == null)
            {
                return BadRequest("The user could not be found.");
            }
            else
            {
                return Ok(found);
            }      
        }

        // criação de usuário
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(string))]
        public IHttpActionResult Post(UserTeamDTO userToCreate)
        {
            if (userToCreate == null)
            {
                return BadRequest("The user object is empty.");
            }
            else
            {
                UserTeamMethods.Create(userToCreate);
                return Created(new Uri("api/users", UriKind.Relative), "User created with success.");
            }
        }

        // atualiza usuario pelo id e body preenchido
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, UserTeamDTO userToUpdate)
        {
            if (UserTeamMethods.Find(id) == null)
            {
                return BadRequest("The user could not be found.");
            }
            else
            {
                UserTeamMethods.Update(id, userToUpdate);
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
        }

        // delete usuário pelo id
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (UserTeamMethods.Find(id) == null)
            {
                return BadRequest("The user could not be found.");
            }
            else
            {
                UserTeamMethods.Delete(id);
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
        }
    }
}

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
            var userTeamMethods = new UserTeamMethods();
            return Ok(userTeamMethods.Display());
        }

        // pega user por id
        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(UserTeamDTO))]
        public IHttpActionResult GetById(int id)
        {
            var userTeamMethods = new UserTeamMethods();
            var found = userTeamMethods.Find(id);
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
            var userTeamMethods = new UserTeamMethods();
            if (userToCreate == null)
            {
                return BadRequest("The user object is empty.");
            }
            else
            {
                userTeamMethods.Create(userToCreate);
#warning Deve aplicado o ID na URI
                return Created(new Uri("api/users", UriKind.Relative), "User created with success.");
            }
        }

        // atualiza usuario pelo id e body preenchido
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, UserTeamDTO userToUpdate)
        {
            var userTeamMethods = new UserTeamMethods();
            if (userTeamMethods.Find(id) == null)
            {
                return BadRequest("The user could not be found.");
            }
            else
            {
                userTeamMethods.Update(id, userToUpdate);
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
        }

        // delete usuário pelo id
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var userTeamMethods = new UserTeamMethods();
            if (userTeamMethods.Find(id) == null)
            {
                return BadRequest("The user could not be found.");
            }
            else
            {
                userTeamMethods.Delete(id);
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
        }
    }
}

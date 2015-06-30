using Study.Entity;
using Study.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Business
{
    /// <summary>
    /// Métodos da tabela UserTeam
    /// </summary>
    public class UserTeamMethods
    {
        // Cria um User na tabela
        public static void Create(DTO.UserTeamDTO userTeam)
        {
            // preencho o objeto da tabela
            var userTeamTable = new UserTeamTable
            {
                CreateDate = userTeam.CreateDate,
                FullName = userTeam.FullName,
                GroupTeamId = userTeam.GroupTeamId,
                IsEnabled = userTeam.IsEnabled,
                Login = userTeam.Login,
                Password = userTeam.Password,
                GroupTeamTable = GroupTeamMethods.Find(userTeam.GroupTeamId)
            };

            // conecta com a base
            using (BaseContext db = new BaseContext())
            {
                // adiciona na tabela o objeto
                db.UserTeam.Add(userTeamTable);

                // salvo as modificações
                db.SaveChanges();
            }
        }
        // Lista os Users da tabela
        public static List<UserTeamTable> Display()
        {
            IList<UserTeamTable> query = null;

            using (BaseContext db = new BaseContext())
            {
                // guardo na variável os itens da tabela ordenados por nome
                query = db.UserTeam.OrderBy(x => x.FullName).ToList();
            }

            // retorno a variável em lista
            return query.ToList();
        }
        // Encontra o Item na tabela de User
        public static UserTeamTable Find(int userTeamId)
        {
            // faço a conexão com a base
            using (BaseContext db = new BaseContext())
            {
                // encontro na base o item que foi passado na chamada da função
                var result = db.UserTeam.FirstOrDefault(x => x.UserTeamId == userTeamId);

                // retorno o item encontrado
                return result;
            }
        }
        // Atualiza o Item da tabela User
        public static void Update(int userTeamId, DTO.UserTeamDTO userTeam)
        {
            // preencho os items que serão atualizados
            var itemToUpdate = Find(userTeamId);
            if (userTeam.FullName != null)
            {
                itemToUpdate.FullName = userTeam.FullName;
            }
            if (userTeam.GroupTeamId != 0)
            {
                itemToUpdate.GroupTeamId = userTeam.GroupTeamId;
                itemToUpdate.GroupTeamTable = GroupTeamMethods.Find(userTeam.GroupTeamId);
            }

            itemToUpdate.IsEnabled = userTeam.IsEnabled;

            if (userTeam.Password != null)
            {
                itemToUpdate.Password = userTeam.Password;
            }

            // faço a conexão com a base
            using (BaseContext db = new BaseContext())
            {
                // digo a base que o estado do item que foi modificado é de 'modificado'
                // se não fizer isso, ele não salva
                db.Entry(itemToUpdate).State = EntityState.Modified;

                // salvo as modificações
                db.SaveChanges();
            }
        }
        // Deleta o Item da tabela User
        public static void Delete(int userTeamId)
        {
            // encontro o item da tabela que quero deletat
            var itemToDelete = Find(userTeamId);

            // faço uma conexão com a base
            using (BaseContext db = new BaseContext())
            {
                // anexo o item que quero deletar na tabela do user
                db.UserTeam.Attach(itemToDelete);

                // deleto o item da tabela
                db.UserTeam.Remove(itemToDelete);

                // salvo as modificações
                db.SaveChanges();
            }
        }
    }
}

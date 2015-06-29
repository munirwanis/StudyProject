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
    /// Métodos para a tabela GroupTeam
    /// </summary>
    public class GroupTeamMethods
    {
        // Cria um grupo na Tabela
        public static void Create(DTO.GroupTeamDTO groupTeam)
        {
            // preencho o objeto que vou criar
            var groupTeamTableEntity = new GroupTeamTable()
            {
                Name = groupTeam.Name,
                Description = groupTeam.Description,
                CreateDate = DateTime.Now
            };

            // faz a conexão com a base
            using (BaseContext db = new BaseContext())
            {
                // adiciona na base o novo item
                db.GroupTeam.Add(groupTeamTableEntity);

                // salva as alterações
                db.SaveChanges();
            }
        }

        // Lista os grupos da tabela
        public static List<GroupTeamTable> Display()
        {
            IList<GroupTeamTable> query = null;

            // faz a conexão com a base
            using (BaseContext db = new BaseContext())
            {
                // monta uma lista ordenando por nomes
                query = db.GroupTeam.OrderBy(x => x.Name).ToList();
            }

            // retorna a lista
            return query.ToList();
        }

        // Encontra o elemento na tabela
        public static GroupTeamTable Find(int groupTeamId)
        {
            // faz a conexão com a base
            using (BaseContext db = new BaseContext())
            {
                // encontra o item pela id e guarda
                var groupTeamFoundItem = db.GroupTeam.FirstOrDefault(x => x.GroupTeamId == groupTeamId);

                // retorna o item
                return groupTeamFoundItem;
            }           
        }

        // Atualiza o elemento da tabela
        public static void Update(int groupTeamId, DTO.GroupTeamDTO groupTeam)
        {
            // encontra e atualiza os campos do item da tabela
            var groupTeamToUpdate = Find(groupTeamId);
            groupTeamToUpdate.Name = groupTeam.Name;
            groupTeamToUpdate.Description = groupTeam.Description;

            // faz a conexão com a base
            using (BaseContext db = new BaseContext())
            {
                // marca a entity como modificada para salvar depois
                db.Entry(groupTeamToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Remove o item da tabela
        public static void Delete(int groupTeamId)
        {
            var groupTeamToDelete = Find(groupTeamId);

            // faz a conexão com a base
            using (BaseContext db = new BaseContext())
            {
                // anexa na base o item a ser deletado
                db.GroupTeam.Attach(groupTeamToDelete);

                // remove o item da base
                db.GroupTeam.Remove(groupTeamToDelete);

                // salva as modificações
                db.SaveChanges();
            }
        }
    }
}

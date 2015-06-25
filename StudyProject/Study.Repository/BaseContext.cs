using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Study.Entity;

namespace Study.Repository
{
    /// <summary>
    /// DataBase de Grupos e Usuários
    /// </summary>
    public class BaseContext : DbContext
    {
        public BaseContext()
            : base("Name=SystemGroupTeamDataBase")
        {

        }
        public DbSet<GroupTeamTable> GroupTeam { get; set; }
        public DbSet<UserTeamTable> UserTeam { get; set; }
    }
}

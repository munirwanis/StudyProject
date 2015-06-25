using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Business.DTO
{
    /// <summary>
    /// DTO para criação de grupo
    /// </summary>
    public class GroupTeamDTO
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
    }
}

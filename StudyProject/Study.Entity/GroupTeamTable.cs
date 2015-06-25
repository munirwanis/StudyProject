using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Entity
{
    /// <summary>
    /// Tabela GroupTeam
    /// </summary>
    public class GroupTeamTable
    {
        [Key]
        public int GroupTeamId { get; set; }

        [Required]
        public string Name { get; set; }

        // DataAnnotations
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

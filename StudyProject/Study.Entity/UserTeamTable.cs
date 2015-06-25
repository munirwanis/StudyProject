using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Entity
{
#warning Adicionar Atributos Annotaion
#warning Adicionar comentário
    public class UserTeamTable
    {
        [Key]        
        public int UserTeamId { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Login { get; set; }
        
        public string FullName { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        
        public bool IsEnabled { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public int GroupTeamId { get; set; }

        [ForeignKey("GroupTeamId")]
        public GroupTeamTable GroupTeamTable { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Business.DTO
{
    public class UserTeamDTO
    {
        public string Login { get; set; }

        public string FullName { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsEnabled { get; set; }

        public string Password { get; set; }

        public int GroupTeamId { get; set; }
    }
}

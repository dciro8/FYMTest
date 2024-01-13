using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string IdentificaionCode { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}

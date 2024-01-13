using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain.DTO
{
    public class InfoUserDto
    {
        public Guid? Id { get; set; }
        public string? DocumentType { get; set; } = null!;
        public string? DocumentNumber { get; set; } = null!;
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? CodeRole { get; set; }
        public bool? State { get; set; }
    }
}

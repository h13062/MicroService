using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Core.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        [Column(TypeName = "nvarchar(129)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}
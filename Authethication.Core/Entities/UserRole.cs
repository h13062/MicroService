﻿namespace Authentication.Core.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Account User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
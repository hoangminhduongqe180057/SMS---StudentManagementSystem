using Microsoft.AspNetCore.Identity;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Photo { get; set; }
        public int GenderId { get; set; }
        public SystemCodeDetail Gender {  get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public string RoleId { get; set; }
        public ApplicationRole Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeactivatedOn {  get; set; }
        public DateTime LastActivityDate { get; set; }


    }

}
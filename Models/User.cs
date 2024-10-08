﻿using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace jobify_Backend.Models
{
    public class User
    {
        [Key]
        public int UserId{ get; set; }
        public string UserName { get; set; }
        public string? JobTitle{ get; set; }
        public string? Location { get; set; }
        public string? Bio { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Navigation property for the jobs this user has applied to
        public ICollection<JobApplication> JobApplications { get; set; }

    }
}

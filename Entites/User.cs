﻿using System.ComponentModel.DataAnnotations;

namespace projetoCaixa.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? PasswordHash { get; set; }

    }
}
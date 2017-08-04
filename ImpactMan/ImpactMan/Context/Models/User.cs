﻿using System.ComponentModel.DataAnnotations;

namespace ImpactMan.Context.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }
    }
}

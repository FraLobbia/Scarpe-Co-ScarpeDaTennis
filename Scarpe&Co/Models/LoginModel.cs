﻿using System.ComponentModel.DataAnnotations;

namespace Scarpe_Co.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Il campo Username è obbligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Il campo Password è obbligatorio.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

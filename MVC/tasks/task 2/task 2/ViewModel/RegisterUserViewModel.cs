﻿using System.ComponentModel.DataAnnotations;

namespace task_2.ViewModel
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
    }
}

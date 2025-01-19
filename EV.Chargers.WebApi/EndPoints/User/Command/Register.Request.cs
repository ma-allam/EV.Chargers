﻿using System.ComponentModel.DataAnnotations;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class RegisterEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/Register/";


        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

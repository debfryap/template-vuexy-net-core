using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BfiBaseTemplate.Service.Validations
{
    public class UserRegisteredAttribute : ValidationAttribute
    {
        private LoginService loginService;
        public UserRegisteredAttribute(LoginService loginService)
        {
            this.loginService = loginService;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var inputValue = value as string;
            //if (!this.loginService.UserRegistered(inputValue))
            //{
            //    return new ValidationResult("Email not Registered");
            //}
            //if (!this.loginService.IsActiveUser(inputValue))
            //{
            //    return new ValidationResult("Your account not active");
            //}
            return ValidationResult.Success;
        }
    }
}

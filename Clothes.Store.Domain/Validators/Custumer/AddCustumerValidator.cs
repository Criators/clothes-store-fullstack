using Clothes.Store.Domain.Models.InputModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Domain.Validators.Custumer
{
    public class AddCustumerValidator : AbstractValidator<CustumerInputModel>
    {
        public AddCustumerValidator()
        {
            RuleFor(n => n.CustumerName)
                .NotEmpty()
                    .WithMessage("Name must not be null")
                .MaximumLength(100)
                    .WithMessage("Name lenght must be less than 50")
                .MinimumLength(5)
                    .WithMessage("Name lenght must be more than 5");

            RuleFor(e => e.Email)
                .NotEmpty()
                    .WithMessage("Email must not be null")
                .MaximumLength(100)
                    .WithMessage("Email lenght must be less than 100")
                .MinimumLength(10)
                    .WithMessage("Email lenght must be more than 10")
                .Must(e => e.IsValidEmail())
                    .WithMessage("Invalid Email! Verify the structure in your email.");

            RuleFor(c => c.CPF)
                .NotEmpty()
                    .WithMessage("CPF must not be null")
                .MaximumLength(14)
                    .WithMessage("CPF lenght must be less than 14")
                .MinimumLength(14)
                    .WithMessage("CPF lenght must be more than 14")
                .Must(c => c.IsValidCPF())
                    .WithMessage("Invalid CPF! Verify the structure in your CPF.");

            RuleFor(p => p.Password)
                .NotEmpty()
                    .WithMessage("Password must not be null")
                .MaximumLength(16)
                    .WithMessage("Password lenght must be less than 16")
                .MinimumLength(8)
                    .WithMessage("Password lenght must be more than 8");

            RuleFor(u => u.UserType)
                .NotEmpty()
                    .WithMessage("User type must not be null")
                .IsInEnum()
                    .WithMessage("Invalid user type");
        }
    }
}

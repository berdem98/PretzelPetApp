using EntityLayer.Concrete;
using FluentValidation;

namespace PretzelPetApp.ValidationRules
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen isminizi giriniz.");
            RuleFor(x => x.CustomerSurname).NotEmpty().WithMessage("Lütfen soyadınızı giriniz.");
            RuleFor(x => x.CustomerPassword).NotEmpty().WithMessage("Lütfen şifre giriniz.");
            RuleFor(x => x.CustomerMail).NotEmpty().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(x => x.CustomerAdress).NotEmpty().WithMessage("Lütfen Adres giriniz.");
            RuleFor(x => x.CustomerName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");

        }
        
    }
}

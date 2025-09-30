using FluentValidation;
using Jalasoft.Interns.Service.Domain.Cities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.Service.Validators.Cities
{
    public class HospitalValidator : AbstractValidator<Hospital>
    {
        public HospitalValidator()
        {
            RuleFor(h => h.Name)
                .NotEmpty()
                .WithMessage("Name of the hospital can not be empty")
                .WithErrorCode("HOSP001");

            RuleFor(h => h.Address)
                .NotEmpty()
                .WithMessage("Address is required")
                .WithErrorCode("HOSP002");

            RuleFor(h => h.Address)
                .Must(BeAValidAddress)
                .WithMessage("Address must start with Av. or St.")
                .WithErrorCode("HOSP003")
                .When(h => !string.IsNullOrEmpty(h.Address));
        }
        private bool BeAValidAddress(string address)
        {
            return address.StartsWith("Av.") || address.StartsWith("St.");
        }
    }
    public class CityValidator : AbstractValidator<City> 
    {
        public CityValidator() {
            RuleFor(c => c.Capital)
               .NotEmpty()
               .WithMessage("Capital can not be empty")
               .WithName("Capital")
               .WithErrorCode("CITY001")
               .WithSeverity(Severity.Error);

            RuleFor(c => c.Capital)
                .MinimumLength(3)
                .WithMessage("Capital must have at least 3 characters")
                .WithErrorCode("CITY002")
                .WithSeverity(Severity.Warning);

            RuleFor(c => c.Capital)
                .MaximumLength(50)
                .WithMessage("Capital must not exceed 50 characters")
                .WithErrorCode("CITY003");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("City name is required")
                .WithErrorCode("CITY004");

            RuleFor(c => c.GPD)
                .GreaterThan(0)
                .WithMessage("GPD must be greater than 0")
                .WithErrorCode("CITY006")
                .WithSeverity(Severity.Error);

            RuleFor(c => c.Country)
                .NotEmpty()
                .WithMessage("Country is required")
                .WithErrorCode("CITY008");

            RuleFor(c => c.Country)
                .Matches("^[A-Z]{2,10}$")
                .WithMessage("Country must be uppercase letters only")
                .WithErrorCode("CITY010")
                .WithSeverity(Severity.Info);

            RuleFor(c => c.Hospitals)
                .NotNull()
                .WithMessage("Hospitals list cannot be null")
                .WithErrorCode("CITY011");

            RuleFor(c => c.Hospitals)
                .NotEmpty()
                .WithMessage("City must have at least one hospital")
                .WithErrorCode("CITY012")
                .WithSeverity(Severity.Warning);

            RuleForEach(c => c.Hospitals)
                .SetValidator(new HospitalValidator())
                .When(c => c.Hospitals != null);

            RuleFor(c => c.Hospitals)
                .Must(NotHaveDuplicateHospitalNames)
                .WithMessage("Hospital names must be unique")
                .WithErrorCode("CITY013")
                .When(c => c.Hospitals != null && c.Hospitals.Any());
        }

        private bool NotHaveDuplicateHospitalNames(IList<Hospital> hospitals)
        {
            if (hospitals == null) return true;

            var hospitalNames = hospitals.Select(h => h.Name).Where(n => !string.IsNullOrEmpty(n));
            return hospitalNames.Count() == hospitalNames.Distinct().Count();
        }
    }
    }
}

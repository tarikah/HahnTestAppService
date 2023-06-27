using FluentValidation;
using HahnTestAppService.Contracts.Request;

namespace HahnTestAppService.Contracts.Validations
{
    public class UpdatePartValidator : AbstractValidator<UpdatePartRequest>
    {
        public UpdatePartValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Composition).NotEmpty().NotNull();
            RuleFor(x => x.SerialNumber).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(x => x.ManufacturerId).NotEmpty().NotNull();
            RuleFor(x => x.PartTypeId).NotEmpty().NotNull();
            RuleFor(x => x.TotalQuantity).NotEmpty().NotNull();
        }
    }
    public class AddPartValidator : AbstractValidator<AddPartRequest>
    {
        public AddPartValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Composition).NotEmpty().NotNull();
            RuleFor(x => x.SerialNumber).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(x => x.ManufacturerId).NotEmpty().NotNull();
            RuleFor(x => x.PartTypeId).NotEmpty().NotNull();
            RuleFor(x => x.TotalQuantity).NotEmpty().NotNull();
        }
    }
}

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using MyWebApp.Data;

namespace MyWebApp.Validation
{
    public class AnimatronicValidator 
        : AbstractValidator<Animatronic>
    {
        public AnimatronicValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Name must be described!");
            RuleFor(x => x.Name).MaximumLength(30)
                .WithMessage("Name must be shoter! Max: 30 characters");

            RuleFor(x => x.StageNickname).NotEmpty()
                .WithMessage("Stage nickname is a must!");
            RuleFor(x => x.StageNickname).MaximumLength(10)
                .WithMessage("Stage name must be short! Max: 10 characters");

            RuleFor(x => x.StagePrescription).NotEmpty()
                .WithMessage("Stage prescription must be described!");
            RuleFor(x => x.StagePrescription).MinimumLength(4)
                .WithMessage("Stage prescription is invalid! No stage has a short name!");

            RuleFor(x => x.Description).MaximumLength(100)
                .WithMessage("Description must be shorter! Max: 100 characters");

        }
    }
}

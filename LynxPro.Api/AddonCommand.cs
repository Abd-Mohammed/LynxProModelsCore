using FluentValidation;
using LynxPro.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LynxPro.Api;

public class AddonCommand
{
    [BindRequired]
    public string Id { get; set; }

    [BindRequired]
    public string Name { get; set; }

    [BindRequired]
    public AddonType Type { get; set; }
}

public class AddonCommandValidator : AbstractValidator<AddonCommand>
{
    public AddonCommandValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty();
        
        RuleFor(a => a.Id)
            .NotEmpty();

        RuleFor(a => a.Type)
            .NotEmpty()
            .IsInEnum();
    }
}
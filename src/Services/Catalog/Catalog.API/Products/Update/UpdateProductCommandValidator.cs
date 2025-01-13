using FluentValidation;

namespace Catalog.API.Products.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product id must be greater than zero.");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters."); 

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("At least one category is required.")
            .Must(cat => cat != null && cat.All(c => !string.IsNullOrWhiteSpace(c)))
            .WithMessage("All category names must be valid and not empty.");

        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");

        RuleFor(x => x.ImagePath)
            .NotEmpty().WithMessage("Image path is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}
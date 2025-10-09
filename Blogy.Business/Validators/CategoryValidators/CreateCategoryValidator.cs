using Blogy.Business.DTOS.CategoryDtos;
using FluentValidation;

namespace Blogy.Business.Validators.CategoryValidators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(a => a.Name).NotEmpty().WithMessage("Kategori Adı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori Adı En az üç karakter olmalı")
            .MaximumLength(50).WithMessage("Kategori Adı En fazla 50 Karakter olmalı.");

    }
}

using Blogy.Entities.Concrete;
using FluentValidation;

namespace Blogy.Business.Validators;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(a=>a.UserId).NotEmpty().WithMessage("Kullanıcı boş geçilemez");
        RuleFor(a=>a.BlogId).NotEmpty().WithMessage("Blog boş geçilemez");
        RuleFor(a=>a.Content).NotEmpty().WithMessage("Yorum içeriği boş geçilemez")
            .MaximumLength(250).WithMessage("Yorum içeriği 250 karakterden uzun olamaz");

    }
}

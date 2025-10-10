using Blogy.Business.DTOS.BlogDtos;
using FluentValidation;

namespace Blogy.Business.Validators.BlogValidators;

public class UpdateBlogValidator : AbstractValidator<UpdateBlogDto>
{
    public UpdateBlogValidator()
    {
        RuleFor(a => a.Title).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez")
           .MaximumLength(100).WithMessage("Başlık Alanı En Fazla 100 Karakter Olabilir")
           .MinimumLength(5).WithMessage("Başlık Alanı En Az 5 Karakter Olabilir");
        RuleFor(a => a.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez");
        RuleFor(a => a.CoverImage).NotEmpty().WithMessage("Kapak Resmi Alanı Boş Geçilemez");
        RuleFor(a => a.BlogImage1).NotEmpty().WithMessage("Blog Resmi 1 Alanı Boş Geçilemez");
        RuleFor(a => a.BlogImage2).NotEmpty().WithMessage("Blog Resmi 2 Alanı Boş Geçilemez");
        RuleFor(a => a.CategoryId).NotEmpty().WithMessage("Kategori Alanı Boş Geçilemez");
    }
}

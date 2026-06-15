using FluentValidation;
using MyFlix.Api.DTOs;

namespace MyFlix.Api.Validators
{
    public class UpdateMovieDtoValidator : AbstractValidator<UpdateMovieDto>
    {
        public UpdateMovieDtoValidator()
        {
            RuleFor(x => x.Title)
           .NotEmpty()
           .MaximumLength(200);

            RuleFor(x => x.Genre)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.ReleaseYear)
                .InclusiveBetween(1888, DateTime.Now.Year + 1);

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5)
                .When(x => x.Rating.HasValue);
        }
    }
}

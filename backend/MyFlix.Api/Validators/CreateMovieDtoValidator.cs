using FluentValidation;
using MyFlix.Api.DTOs;

namespace MyFlix.Api.Validators
{
    public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
    {
        public CreateMovieDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Genre)
               .NotEmpty()
               .MaximumLength(100);

            RuleFor(x => x.ReleaseYear)
                .InclusiveBetween(1888, DateTime.Now.Year + 1);
           
        }
    }
}

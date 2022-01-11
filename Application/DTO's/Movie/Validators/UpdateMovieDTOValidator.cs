using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Movie.Validators
{
    public class UpdateMovieDTOValidator : AbstractValidator<UpdateMovieDTO>
    {
        public UpdateMovieDTOValidator()
        {
            RuleFor(p => p.Name)
                        .NotEmpty().WithMessage("{PropertyName} no puede estar vacío");

            RuleFor(p => p.TicketPrice)
                    .GreaterThan(0).WithMessage("{PropertyName} tiene que ser mayor a {ComparisonValue}");

            RuleFor(p => p.Description)
                    .NotEmpty().WithMessage("{PropertyName} no puede estar vacío");
        }
    }
}

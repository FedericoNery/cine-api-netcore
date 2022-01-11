using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Movie.Validators
{
    public class DeleteMovieDTOValidator : AbstractValidator<DeleteMovieDTO>
    {
        public DeleteMovieDTOValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");
        }
    }
}

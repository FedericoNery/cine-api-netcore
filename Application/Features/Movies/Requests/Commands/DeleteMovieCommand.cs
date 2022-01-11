using Application.DTO_s.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.Requests
{
    public class DeleteMovieCommand : IRequest
    {
        public DeleteMovieDTO DeleteMovieDTO { get; set; }
    }
}

using Application.Features.Movies.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Commands
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        public Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

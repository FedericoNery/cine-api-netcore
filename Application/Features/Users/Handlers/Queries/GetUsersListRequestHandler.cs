using Application.DTO_s;
using Application.Features.Users.Requests.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Handlers.Queries
{
    public class GetUsersListRequestHandler : IRequestHandler<GetUsersListRequest, List<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListRequestHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> Handle(GetUsersListRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();
            return new List<UserDTO>();
        }
    }
}

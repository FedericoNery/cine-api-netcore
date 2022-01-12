using Application.DTO_s;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Users.Requests.Queries
{
    public class GetUsersListRequest : IRequest<List<UserDTO>>
    {
    }
}

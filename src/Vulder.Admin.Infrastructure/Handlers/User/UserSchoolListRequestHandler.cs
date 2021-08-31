using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;
using Vulder.Admin.Infrastructure.Data.Interfaces;

namespace Vulder.Admin.Infrastructure.Handlers.User
{
    public class UserSchoolListRequestHandler : IRequestHandler<JwtModel, UserSchoolListDto>
    {
        private readonly IUserRepository _userRepository;
        
        public UserSchoolListRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<UserSchoolListDto> Handle(JwtModel request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            
            return new UserSchoolListDto
            {
                Schools = user.SchoolCollection
            };
        }
    }
}
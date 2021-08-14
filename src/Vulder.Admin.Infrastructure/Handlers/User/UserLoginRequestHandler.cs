using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Admin.Core.Exceptions;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Core.Utils;
using Vulder.Admin.Infrastructure.Data.Interfaces;

namespace Vulder.Admin.Infrastructure.Handlers.User
{
    public class UserLoginRequestHandler : IRequestHandler<Core.Models.User, UserDto>
    {
        private readonly IUserRepository _userRepository;
        
        public UserLoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<UserDto> Handle(Core.Models.User request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetUserByEmail(request.Email);
            if (string.IsNullOrEmpty(entity.Id.ToString()))
                throw new UserNotFoundException("User not found");
            if (PasswordHashUtil.VerifyHash(request.Password, entity.Password))
            {
                return new UserDto
                {
                    Id = entity.Id,
                    Email = entity.Email
                };
            }
            throw new UserNotValidPasswordException("User password is invalid");
        }
    }
}
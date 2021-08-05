using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Infrastructure.Data;

namespace Vulder.Admin.Infrastructure.Handlers.User
{
    public class NewUserRequestHandler : IRequestHandler<Core.ProjectAggregate.User.User, UserDto>
    {
        private readonly EfRepository<Core.ProjectAggregate.User.User> _userRepository;
        
        public NewUserRequestHandler(EfRepository<Core.ProjectAggregate.User.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(Core.ProjectAggregate.User.User request, CancellationToken cancellationToken)
        {
            await _userRepository.AddAsync(request);
            return new UserDto
            {
                Id = request.Id,
                Email = request.Email
            };
        }
    }
}
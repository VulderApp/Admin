using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Admin.Core.ProjectAggregate.User.Events;

namespace Vulder.Admin.Core.ProjectAggregate.User.Handlers
{
    public class NewUserHandler : INotificationHandler<NewUserEvent>
    {
        public Task Handle(NewUserEvent notification, CancellationToken cancellationToken)
        {
            
        }
    }
}
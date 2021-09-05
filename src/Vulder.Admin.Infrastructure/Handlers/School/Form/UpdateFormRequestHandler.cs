using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Infrastructure.Data.Interfaces;

namespace Vulder.Admin.Infrastructure.Handlers.School.Form
{
    public class UpdateFormRequestHandler : IRequestHandler<UpdateSchoolModel, Unit>
    {
        private readonly ISchoolFormRepository _repository;
        
        public UpdateFormRequestHandler(ISchoolFormRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateSchoolModel request, CancellationToken cancellationToken)
        {
            var form = await _repository.GetAsync(request.Id);
            
            form.UpdateTimestamp();
            form.SchoolName = request.SchoolName;
            form.TimetableUrl = request.TimetableUrl;
            form.SchoolUrl = request.SchoolUrl;
            
            await _repository.UpdateAsync(form);
            
            return Unit.Value;
        }
    }
}
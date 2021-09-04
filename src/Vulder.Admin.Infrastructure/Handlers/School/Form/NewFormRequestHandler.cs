using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.SchoolForm;
using Vulder.Admin.Infrastructure.Data.Interfaces;

namespace Vulder.Admin.Infrastructure.Handlers.School.Form
{
    public class NewFormRequestHandler : IRequestHandler<SchoolForm, bool>
    {
        private readonly ISchoolFormRepository _repository;
        
        public NewFormRequestHandler(ISchoolFormRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<bool> Handle(SchoolForm request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(request);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
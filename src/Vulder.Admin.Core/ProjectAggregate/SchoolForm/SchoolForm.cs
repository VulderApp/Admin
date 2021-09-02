using System;
using MediatR;
using Vulder.SharedKernel;
using Vulder.SharedKernel.Interface;

namespace Vulder.Admin.Core.ProjectAggregate.SchoolForm
{
    public class SchoolForm : BaseEntity, IAggregateRoot, IRequest<bool>
    {
        public Guid RequesterId { get; set; }
        public string SchoolName { get; set; }
        public string TimetableUrl { get; set; }
        public string SchoolUrl { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public Guid ApprovedBy { get; set; }
        public DateTimeOffset ApprovedAt { get; set; }

        public SchoolForm GenerateId()
        {
            Id = Guid.NewGuid();
            return this;
        }
        
        public SchoolForm CreateTimestamp()
        {
            CreateAt = DateTimeOffset.Now;
            return this;
        }

        public SchoolForm UpdateTimestamp()
        {
            UpdatedAt = DateTimeOffset.Now;
            return this;
        }

        public SchoolForm ApprovedTimestamp()
        {
            ApprovedAt = DateTimeOffset.Now;
            return this;
        }
    }
}
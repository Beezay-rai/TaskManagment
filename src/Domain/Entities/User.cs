 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Abstractions;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Events.User;

namespace TaskManagement.Domain.Entities
{
    public sealed class User : BaseAuditableEntity, IEventableEntity
    { 
        public string Name { get; init; }

        public static User CreateUser(string name)
        {
            var user = new User()
            {
                Name = name,
            };
            return user;
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            throw new NotImplementedException();
        }

        public void ClearDomainEvents()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            throw new NotImplementedException();
        }
    }
}

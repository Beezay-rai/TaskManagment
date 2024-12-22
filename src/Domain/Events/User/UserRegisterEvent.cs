using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Abstractions;

namespace TaskManagement.Domain.Events.User
{
    public class UserRegisterEvent:IDomainEvent
    {
        public string Id { get;  }
        public string Name { get;  }
        public DateTime CreatedDate { get;  }
        public UserRegisterEvent(string id, string name)
        {
            Id = id;
            Name = name;
            CreatedDate= DateTime.UtcNow;
        }
    }
}

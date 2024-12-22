﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities
{
    public sealed class TaskCategory:BaseEntity    
    {
        public string Name { get; init; }
    }
}

﻿using MyStore.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Core.Commands
{
    public abstract class Command:Message
    {
        public DateTime TimeStamp { get;protected set; }
        protected Command()
        {
            TimeStamp = DateTime.Now;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Exceptions.BaseExceptions;

namespace Domain.Exceptions
{
    public class SelfForwardingNotAllowedException : BadRequestException
    {
        public SelfForwardingNotAllowedException()
            : base("You can't forward letter to yourself") { }
    }
}
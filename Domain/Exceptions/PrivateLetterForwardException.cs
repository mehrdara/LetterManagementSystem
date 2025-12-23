using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Exceptions.BaseExceptions;

namespace Domain.Exceptions
{
    public class PrivateLetterForwardException : BadRequestException
    {
        public PrivateLetterForwardException()
            : base("Can't forward a private letter") { }

    }
}
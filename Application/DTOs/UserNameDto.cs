using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record UserNameDto(int Id, string UserName,string Password="Password123!");
}

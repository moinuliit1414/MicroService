using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Authentication
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(string scheme, string policy = "") : base(policy)
        {
            AuthenticationSchemes = scheme;
        }
    }
}

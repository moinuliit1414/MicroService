﻿using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Triplicata.Core.Authentication
{
    public class JwtAuthAttribute : AuthAttribute
    {
        public JwtAuthAttribute(string policy = "") : base(JwtBearerDefaults.AuthenticationScheme, policy)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Chargers.Core.Auth.JWT
{
    public class TokenContext
    {
        public JsonWebToken AccessToken { get; set; }
        public JsonWebToken RefreshToken { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace client.web
{
    public class Token
    {
        public string accessToken { get; set; }
        public int expiresIn { get; set; }
    }

    public class TokenData
    {
        public string errCode { get; set; }
        public string errMsg { get; set; }

        public Token data { get; set; }
    }
}

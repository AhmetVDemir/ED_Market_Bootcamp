using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //token
        public string Token { get; set; }

        //bitiş zamanı
        public DateTime Expiration { get; set; }
    }
}

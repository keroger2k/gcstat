using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamechanger
{
    public class ClientAuthorizationResponse
    {
        public string type {  get; set; }
        public string token { get; set; }
        public int expires { get; set; }
    }

}

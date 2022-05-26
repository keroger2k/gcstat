using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamechanger
{
    public class PasswordChallengeResponse
    {
        public string type { get; set; }
        public PasswordOptions password_params { get; set; }
        public PasswordOptions challenge_params { get; set; }
    }

    public class PasswordOptions
    {
        public string alg { get; set; }
        public string salt { get; set; }
    }  
}

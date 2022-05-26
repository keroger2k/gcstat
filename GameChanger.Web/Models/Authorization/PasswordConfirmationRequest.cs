using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamechanger
{
    public class PasswordConfirmationRequest
    {
        public string type {  get {return "password"; } }
        public string password { get; set; }    
    }
    public class PasswordConfirmationResponse
    {
    }
}

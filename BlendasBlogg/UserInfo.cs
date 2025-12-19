using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public struct UserInfo
    {
        public UserInfo() { }
        private string blendasUsername = "1";
        private string blendasPassword = "1";

        // "Stampe4ever<3"
        // "BlendaIsCool123"
        public string BlendasUsername { get { return blendasUsername; } }  
        public string BlendasPassword { get { return blendasPassword; } }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

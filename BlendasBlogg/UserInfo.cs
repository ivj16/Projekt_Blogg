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
        private string blendasUsername = "BlendaIsCool123";
        private string blendasPassword = "Stampe4ever<3";
        public string BlendasUsername { get { return blendasUsername; } }  
        public string BlendasPassword { get { return blendasPassword; } }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

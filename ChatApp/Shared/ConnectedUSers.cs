using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Shared
{
    public static class ConnectedUsers
    {
        public static Dictionary<string, User> UserConnections = new Dictionary<string, User>();
    }
}

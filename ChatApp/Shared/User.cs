using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Shared
{
    public class User
    {
        public static Dictionary<string, string> UserConnections = new Dictionary<string, string>();
        [Required(ErrorMessage = "Please fill out a User Name to display in the chat.")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Please fill in your first name (or an alias).")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ConnectionID { get; set; }
    }
}

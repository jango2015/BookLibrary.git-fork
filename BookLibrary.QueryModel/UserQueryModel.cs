using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.QueryModel
{
    public class UserQueryModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDateTime { get; set; }
    }
}

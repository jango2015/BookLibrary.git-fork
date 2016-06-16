using System;

namespace BookLibrary.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDateTime { get; set; }
    }
}
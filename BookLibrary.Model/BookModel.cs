using System;

namespace BookLibrary.Model
{
    public class BookModel
    {
        public string Name { get;  set; }

        public string ISBN { get;  set; }

        public string Author { get;  set; }

        public decimal Price { get;  set; }

        public int Number { get;  set; }

        public DateTime PublishDate { get;  set; }
    }
}
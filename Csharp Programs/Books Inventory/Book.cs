using System;
using System.Collections.Generic;
using System.Text;

namespace Books_Inventory
{
    class Books
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Books(string Title, string Author)
        {
            this.Title = Title;
            this.Author = Author;
        }
        public Books(string Title, string Author, int Id)
        {
            this.Title = Title;
            this.Author = Author;
            this.Id = Id;
        }
    }
}

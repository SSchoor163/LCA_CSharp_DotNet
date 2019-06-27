using System;

namespace Books_Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            BookContext Inventory = new BookContext();
            Inventory.Database.EnsureCreated();
            int Menu = printMenu();
            while ( Menu != 0)
            {
                switch (Menu)
                {
                    case 1: //print books
                        printBooks(Inventory);
                        break;
                    case 2: // add book
                        createBook(Inventory);
                        break;
                    case 3: //update book

                        break;
                    case 4: // delete book
                        break;
                }

            }
        }

       static int printMenu()
        {
            
            Console.Clear();
            Console.Write("Book Inventory Main Menu\n" +
                          "-------------------------------------\n" +
                          "1. Print Inventory\n" +
                          "2. Add Book to Inventory\n" +
                          "3. Update Book in Inventory\n" +
                          "4. Delete Book in Inventory\n" +
                          "5. Close Inventory Program");
            string choice = Console.ReadLine();
            while(choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5"){
                Console.WriteLine("Invalid Menu Entry. Please Enter Menu Entry 1-5");
                choice = Console.ReadLine();
            }
            return int.Parse(choice);
        }
        static void createBook(BookContext Inventory)
        {
            string title, author, final;
            GetInfo();
            while(final != "y" && final != "n")
            {
                Console.WriteLine($"Invalid y/n entry. Is {title} | {author} correct? y/n");
                final = Console.ReadLine();
                final = final.ToLower();
            }
            if (final == "y") {
                Inventory.books.Add(new Books(title, author));
                Inventory.SaveChanges();
                    }
            else
            {
                GetInfo();
            }
            void GetInfo()
            {
                Console.Write("Please enter the book title: ");
                title = Console.ReadLine();
                Console.Write("Please enter the book author: ");
                author = Console.ReadLine();
                Console.Write($"You entered {title} | {author}. Is this correct? y/n");
                final = Console.ReadLine();
                final = final.ToLower();
            }
        }
        static void deleteBook(BookContext Inventory)
        {

        }
        static void updateBook(BookContext Inventory)
        {
            Console.Clear();
            printBooks(Inventory);
            int choice;
            string title, author, final;
            Console.WriteLine("Please enter the Id of the book you wish to edit: ");
            choice = int.Parse(Console.ReadLine());
            Console.Write("Please enter the new book title: ");
            title = Console.ReadLine();
            Console.Write("Please enter the new book author: ");
            author = Console.ReadLine();
            Console.Write($"You entered {title} | {author} to replace {Inventory.books.Find(choice).Title} | {Inventory.books.Find(choice).Author}. Is this correct? y/n");
            final = Console.ReadLine();
            final = final.ToLower();
            if(final == "y")
            {
                Inventory.books.
            }
            
        } 
        static void printBooks(BookContext Inventory)
        {
            foreach(Books b in Inventory.books)
            {
                Console.WriteLine($"{b.Id} | {b.Title} | {b.Author}");
            }
            Console.WriteLine("Press any key to return to menu...");
        }
    }
}

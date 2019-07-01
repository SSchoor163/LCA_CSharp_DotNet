using System;

namespace Books_Inventory
{
    class Program
    {
        static int TotalBooks = 0;
        static void Main(string[] args)
        {
            BookContext Inventory = new BookContext();
            Inventory.Database.EnsureCreated();
            foreach (Books b in Inventory.books)
                TotalBooks++;
            int Menu = printMenu();
            while ( Menu != 5)
            {
                switch (Menu)
                {
                    case 1: //print books
                        printBooks(Inventory);
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadLine();
                        break;
                    case 2: // add book
                        createBook(Inventory);
                        break;
                    case 3: //update book
                        if(TotalBooks == 0)
                        {
                            Console.WriteLine("There are no entries in the Inventory to update. Please add entries first.");
                            break;
                        }
                        updateBook(Inventory);
                        break;
                    case 4: // delete book
                        if (TotalBooks == 0)
                        {
                            Console.WriteLine("There are no entries in the Inventory to delete. Please add entries first.");
                            break;
                        }
                        deleteBook(Inventory);
                        break;
                }
                Menu = printMenu();
            }
            Console.WriteLine("Press enter to close the program...");
            Console.ReadLine();
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
                          "5. Close Inventory Program\n");
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
            int choice;
            string final;
            Console.Clear();
            printBooks(Inventory);
            Console.WriteLine("Please select an entry to delete by entering it Id: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine($"You have selected {Inventory.books.Find(choice).Title} | {Inventory.books.Find(choice).Author}. Is this correct? (y/n): ");
            final = Console.ReadLine();
            final = final.ToLower();
            while(final != "y" && final != "n")
            {
                Console.WriteLine("Invalid entry. Please enter y to delete this entry, or n to return to main menu.");
                final = Console.ReadLine();
                final = final.ToLower();
            }
            if(final == "y")
            {
                Inventory.books.Remove(Inventory.books.Find(choice));
                Inventory.SaveChanges();
            }
            else
            {
                Console.WriteLine("No entry deleted. Press any key to return to main menu...");
                Console.ReadLine();
            }
        }
        static void updateBook(BookContext Inventory)
        {
            Console.Clear();
            printBooks(Inventory);
            int choice;
            string title, author, final;
            getData();
            if(final == "y")
            {
                Inventory.books.Find(choice).Author = author;
                Inventory.books.Find(choice).Title = title;
                Inventory.SaveChanges();
            }
            else
            {
                Console.WriteLine("No edit performed. Press any key to return to the main menu...");
                Console.ReadLine();
            }
            void getData()
            {
                Console.WriteLine("Please enter the Id of the book you wish to edit: ");
                choice = int.Parse(Console.ReadLine());
                Console.Write("Please enter the new book title: ");
                title = Console.ReadLine();
                Console.Write("Please enter the new book author: ");
                author = Console.ReadLine();
                Console.Write($"You entered {title} | {author} to replace {Inventory.books.Find(choice).Title} | {Inventory.books.Find(choice).Author}. Is this correct? y/n");
                final = Console.ReadLine();
                final = final.ToLower();
            }
        } 
        static void printBooks(BookContext Inventory)
        {
            TotalBooks = 0;
            foreach(Books b in Inventory.books)
            {
                Console.WriteLine($"{b.Id} | {b.Title} | {b.Author}");
                TotalBooks++;
            }
            
        }
    }
}

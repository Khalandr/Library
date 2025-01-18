using System;

class Program
{
    static void Main()
    {
        // Step 1: Create Variables for Books
        string[] books = new string[5];
        bool[] isBorrowed = new bool[5];
        int borrowedCount = 0;

        while (true)
        {
            // Step 5: Loop Indefinitely
            Console.WriteLine("Choose an action: add, remove, display, search, borrow, checkin, or exit");
            string action = Console.ReadLine().ToLower();

            if (action == "add")
            {
                // Step 2: Add a Book
                Console.WriteLine("Enter the title of the book to add:");
                string newBook = Console.ReadLine();

                bool added = false;
                for (int i = 0; i < books.Length; i++)
                {
                    if (string.IsNullOrEmpty(books[i]))
                    {
                        books[i] = newBook;
                        added = true;
                        break;
                    }
                }

                if (!added)
                {
                    Console.WriteLine("No more book slots available.");
                }
            }
            else if (action == "remove")
            {
                // Step 3: Remove a Book
                Console.WriteLine("Enter the title of the book to remove:");
                string bookToRemove = Console.ReadLine();

                bool removed = false;
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] == bookToRemove)
                    {
                        books[i] = null;
                        isBorrowed[i] = false;
                        removed = true;
                        break;
                    }
                }

                if (!removed)
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else if (action == "display")
            {
                // Step 4: Display the List of Books
                Console.WriteLine("Books in the library:");
                for (int i = 0; i < books.Length; i++)
                {
                    if (!string.IsNullOrEmpty(books[i]))
                    {
                        Console.WriteLine($"{books[i]} {(isBorrowed[i] ? "(Borrowed)" : "")}");
                    }
                }
            }
            else if (action == "search")
            {
                // Search for a Book
                Console.WriteLine("Enter the title of the book to search:");
                string bookToSearch = Console.ReadLine();

                bool found = false;
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] == bookToSearch)
                    {
                        Console.WriteLine("Book is available in the library.");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Book is not in the collection.");
                }
            }
            else if (action == "borrow")
            {
                // Borrow a Book
                if (borrowedCount >= 3)
                {
                    Console.WriteLine("You have reached the borrowing limit of 3 books.");
                    continue;
                }

                Console.WriteLine("Enter the title of the book to borrow:");
                string bookToBorrow = Console.ReadLine();

                bool borrowed = false;
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] == bookToBorrow && !isBorrowed[i])
                    {
                        isBorrowed[i] = true;
                        borrowedCount++;
                        borrowed = true;
                        Console.WriteLine("Book borrowed successfully.");
                        break;
                    }
                }

                if (!borrowed)
                {
                    Console.WriteLine("Book is not available for borrowing.");
                }
            }
            else if (action == "checkin")
            {
                // Check-in a Borrowed Book
                Console.WriteLine("Enter the title of the book to check in:");
                string bookToCheckIn = Console.ReadLine();

                bool checkedIn = false;
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] == bookToCheckIn && isBorrowed[i])
                    {
                        isBorrowed[i] = false;
                        borrowedCount--;
                        checkedIn = true;
                        Console.WriteLine("Book checked in successfully.");
                        break;
                    }
                }

                if (!checkedIn)
                {
                    Console.WriteLine("Book is not currently borrowed.");
                }
            }
            else if (action == "exit")
            {
                // Exit the program
                break;
            }
            else
            {
                // Step 6: Handle Invalid Inputs
                Console.WriteLine("Invalid action. Please choose add, remove, display, search, borrow, checkin, or exit.");
            }
        }
    }
}

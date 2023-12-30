﻿// Program.cs
class Program
{
    /// <summary>
    /// Main code for Contact Book app
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome To My Contact Book App!");

        // Create a new instance of the ContactBook
        ContactBook contactBook = new ContactBook();

        while (true)
        {
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. List Contacts");
            Console.WriteLine("3. Show Contact Details");
            Console.WriteLine("4. Remove Contact");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact(contactBook);
                    break;
                case "2":
                    ListContacts(contactBook);
                    break;
                case "3":
                    DisplayContactDetails(contactBook);
                    break;
                case "4":
                    RemoveContact(contactBook);
                    break;
                case "5":
                    contactBook.SaveContacts();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please try again, invalid choice.");
                    break;
            }
        }
    }

    /// <summary>
    /// Main code to add contacts into the contact book app database
    /// </summary>
    /// <param name="contactBook">ContactBook instance</param>
    static void AddContact(ContactBook contactBook)
    {
        // User input for creating a new contact
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter Address: ");
        string address = Console.ReadLine();

        // Optional info for user to type in
        Console.Write("Enter Nickname (optional): ");
        string nickname = Console.ReadLine();
        Console.Write("Enter Birthday (optional): ");
        string birthday = Console.ReadLine();

        // Create a new Contact instance
        Contact contact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email,
            Address = address,
            Nickname = nickname,
            Birthday = birthday
        };
        // Add the contact to the ContactBook
        contactBook.AddContact(contact);
    }

    static void ListContacts(ContactBook contactBook)
    {
        contactBook.ListContacts();
    }

    static void DisplayContactDetails(ContactBook contactBook)
    {
        Console.Write("Enter Email of the contact: ");
        string email = Console.ReadLine();
        contactBook.DisplayContactDetails(email);
    }

    static void RemoveContact(ContactBook contactBook)
    {
        Console.Write("Enter Email of the contact to remove: ");
        string email = Console.ReadLine();
        contactBook.RemoveContact(email);
    }
}

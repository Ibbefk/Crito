// ContactBook.cs
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ContactBook
{
    // List of contacts
    private List<Contact> contacts;

    // List for JSON format Path to store contacts
    private string filePath = "contacts.json";

    // Initializes new instance of the Contactbook class
    public ContactBook()
    {
        // Load contacts from the JSON file
        LoadContacts();
    }
    // Add new contact to the list of contact book
    public void AddContact(Contact contact)
    {
        // Add the contact to the list
        contacts.Add(contact);
        // Save contacts to the file
        SaveContacts();
        // Display a success message
        Console.WriteLine($"Contact {contact.FirstName} {contact.LastName} added successfully.");
    }

    // Removes contact based on the provided email.
    public void RemoveContact(string email)
    {
        Contact contactToRemove = contacts.Find(c => c.Email == email);
        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            SaveContacts();
            Console.WriteLine($"Contact {contactToRemove.FirstName} {contactToRemove.LastName} removed successfully.");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
    // Lists all contacts stored in a formatted way.
    public void ListContacts()
    {
        Console.WriteLine("Contact List:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}, {contact.Email}");
        }
    }
    // Displays detailed info
    public void DisplayContactDetails(string email)
    {
        Contact contact = contacts.Find(c => c.Email == email);
        if (contact != null)
        {
            // Display detailed info about the specified contact
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Phone: {contact.PhoneNumber}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Address: {contact.Address}");
            Console.WriteLine($"Additional Info: Nickname - {contact.Nickname}, Birthday - {contact.Birthday}");
        }
        else
        {
            // Display a message if contact is not found
            Console.WriteLine("Contact not found.");
        }
    }
    // Loads contacts from JSON file
    public void LoadContacts()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
        }
        else
        {
            contacts = new List<Contact>();
        }
    }
    // Saves contacts to JSON file
    public void SaveContacts()
    {
        string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    // Add this method to get the count of contacts
    public int GetContactsCount()
    {
        return contacts.Count;
    }
}

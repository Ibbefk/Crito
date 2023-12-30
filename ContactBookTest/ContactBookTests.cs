// ContactBookTests.cs
using Xunit;

public class ContactBookTests
{
    [Fact]
    public void TestContactBook()
    {
        
        ContactBook contactBook = new ContactBook();
        int initialCount = contactBook.GetContactsCount(); 

        
        contactBook.AddContact(new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" });

        
        int newCount = contactBook.GetContactsCount(); 
        Assert.Equal(initialCount + 1, newCount);
    }
}

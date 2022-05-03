using System;
using Xunit;

namespace GradeBook.Tests;

public delegate string WriteLogDelegate(string logMessage);

public class TypeTests
{
    int count = 0;

    #region Multi Cast Delegate Test
    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log = ReturnMessageMC1;
        log += ReturnMessageMC2;

        var result = log("Hello!");

        Assert.Equal("Hello!", result);
        Assert.Equal(2, count);
    }

    string ReturnMessageMC1(string message)
    {
        count++;
        return message.ToLower();
    }

    string ReturnMessageMC2(string message)
    {
        count++;
        return message;
    }
    #endregion

    #region Delegate Test with Short Hand notation
    [Fact]
    public void WriteLogDelegateCanPointToMethodSH()
    {
        WriteLogDelegate log;
        log = ReturnMessageSH;

        var result = log("Hello!");

        Assert.Equal("Hello!", result);
    }

    string ReturnMessageSH(string message)
    {
        return message;
    }
    #endregion

    #region Delegate Test with Long Hand notation
    [Fact]
    public void WriteLogDelegateCanPointToMethodLH()
    {
        WriteLogDelegate log;
        log = new WriteLogDelegate(ReturnMessageLH);

        var result = log("Hello!");

        Assert.Equal("Hello!", result);
    }

    string ReturnMessageLH(string message)
    {
        return message;
    }
    #endregion

    #region StringBehaveLikeValueTypes
    [Fact]
    public void StringBehaveLikeValueTypes()
    {
        // arrange
        string name = "Ian";

        // act
        var upperCaseName = MakeUpperCase(name);

        // assert
        Assert.Equal("Ian", name);
        Assert.Equal("IAN", upperCaseName);
    }

    private string MakeUpperCase(string name)
    {
        return name.ToUpper();
    }
    #endregion

    #region ValueTypesAlsoPassByValue
    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
        // arrange
        var x = GetInt();

        // act
        SetInt(ref x);

        //assert
        Assert.Equal(45, x);
    }

    private void SetInt(ref int x)
    {
        x = 45;
    }

    private int GetInt()
    {
        return 3;
    }
    #endregion

    #region CSharpCanPassByReference
    [Fact]                  // attribute
    public void CSharpCanPassByReference()
    {
        // arrange
        var book1 = GetBook("Book 1");

        // act
        var book2 = GetBookSetName(ref book1, "Book Name Changed Due to Reference");

        // assert (api)
        Assert.Equal("Book Name Changed Due to Reference", book1.Name);
        // Assert.NotEqual(book1, book2);
    }

    private InMemoryBook GetBookSetName(ref InMemoryBook book, string newBookName)
    {
        book = new InMemoryBook(newBookName);
        return book;
    }
    #endregion

    #region CSharpIsPassByValue
    [Fact]                  // attribute
    public void CSharpIsPassByValue()
    {
        // arrange
        var book1 = GetBook("Book 1");

        // act
        var book2 = GetBookSetName(book1, "Book Name Changed");

        // assert (api)
        Assert.Equal("Book 1", book1.Name);
        Assert.NotEqual(book1, book2);
    }

    private InMemoryBook GetBookSetName(InMemoryBook book, string newBookName)
    {
        book = new InMemoryBook(newBookName);
        return book;
    }
    #endregion

    #region CanSetNameFromReference & TwoVariablesCanReferenceSameObject
    [Fact]                  // attribute
    public void CanSetNameFromReference()
    {
        // arrange
        var book1 = GetBook("Book 1");

        // act
        SetName(book1, "New Book 1");

        // assert (api)
        Assert.Equal("New Book 1", book1.Name);
    }

    [Fact]                  // attribute
    public void TwoVariablesCanReferenceSameObject()
    {
        // arrange
        var book1 = GetBook("Book 1");
        var book2 = book1;

        // act


        // assert (api)
        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }

    private void SetName(InMemoryBook book, string newBookName)
    {
        book.Name = newBookName;
    }

    InMemoryBook GetBook(string bookName)
    {
        return new InMemoryBook(bookName);
    }
    #endregion

    #region GetBookReturnsDifferentObjects
    [Fact]                  // attribute
    public void GetBookReturnsDifferentObjects()
    {
        // arrange
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        // act


        // assert (api)
        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotSame(book1, book2);
    }
    #endregion
}
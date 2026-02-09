namespace eshkere
{
    public class Publisher
{
    public string Name { get; set; }
    public Publisher(string name)
    {
        Name = name;
    }
}
public class Book : ICloneable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public Publisher Publisher { get; set; }
    public Book(string title, string author, int year, Publisher publisher)
    {
        Title = title;
        Author = author;
        Year = year;
        Publisher = publisher;
    }

public Book(Book eshkere)
        {
            Title = eshkere.Title;
            Author = eshkere.Author;
            Year = eshkere.Year;
            Publisher = new Publisher(eshkere.Publisher.Name);
        }
public object Clone()
{
    return new Book(Title, Author, Year, new Publisher(Publisher.Name));
}
public void Print()
{
    Console.WriteLine($"Title: {Title}, Author: {Author}, Year: {Year}, Publisher: {Publisher.Name}");
}
}
class Program
    {
        static void Main()
        {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Publisher pub = new Publisher("я не знаю і знать не хочу");
        Book eshkere = new Book("eshkere", "unknown", 2024, pub);
        Console.WriteLine("Original Book:");
        eshkere.Print();
        Book clonedEshkere = (Book)eshkere.Clone();
        Book copyConstBook = new Book(eshkere);
        eshkere.Publisher.Name = "якийсь новенький";
        eshkere.Title = "змінений";
        Console.WriteLine("після зміни:");
        Console.WriteLine("Original: ");
        eshkere.Print();
        Console.Write("Cloned:   ");
        clonedEshkere.Print();
        Console.Write("CopyCtor: ");
        copyConstBook.Print(); 
        Console.ReadKey();
        }
    }
}
// варірант 3
class Student
{
    private string name;
    private string surname;
    private string groupNumber;
    public Student()
    {
        name = "Владислав";
        surname = "Величко";
        groupNumber = "ІТ-31";
    }
    public Student(string name) : this()
    {
        this.name = name;
    }
    public Student(string name, string surname, string groupNumber)
    {
        this.name = name;
        this.surname = surname;
        this.groupNumber = groupNumber;
    }
    public void DisplayInfo()
    {
        Console.WriteLine("Ім'я: " + name);
        Console.WriteLine("Прізвище: " + surname);
        Console.WriteLine("Група: " + groupNumber);
    }
}
class Program
{
    static void Main()
    {
        Student student1 = new Student();
        Student student2 = new Student("Андрійко");
        Student student3 = new Student("Ещкере", "Ещкеревіч", "ІТ-32");
        student1.DisplayInfo();
        student2.DisplayInfo();
        student3.DisplayInfo();
    }
}
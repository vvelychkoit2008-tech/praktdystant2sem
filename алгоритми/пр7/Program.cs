// для секундоміру
using System.Diagnostics;
// аналіз ефективності
class Program
{
    static void Main()
    {
        int tableSize = 50;
        Random random = new Random();
        List<string> keys = new List<string>();

        for (int i = 0; i < 20; i++)
        {
            string key = "key" + random.Next(1000, 9999);
            keys.Add(key);
        }

        HashTableChaining chaining = new HashTableChaining(tableSize);
        HashTableLinearProbing probing = new HashTableLinearProbing(tableSize);

        Stopwatch sw = new Stopwatch();

        sw.Start();
        foreach (string key in keys)
            chaining.Add(key);
        sw.Stop();
        Console.WriteLine("додавання (ланцюжкове хешування): " + sw.ElapsedTicks);

        sw.Restart();
        foreach (string key in keys)
            chaining.Contains(key);
        sw.Stop();
        Console.WriteLine("пошук (ланцюжкове хешування): " + sw.ElapsedTicks);

        sw.Restart();
        foreach (string key in keys)
            probing.Add(key);
        sw.Stop();
        Console.WriteLine("додавання (лінійне пробування): " + sw.ElapsedTicks);

        sw.Restart();
        foreach (string key in keys)
            probing.Contains(key);
        sw.Stop();
        Console.WriteLine("пошук (лінійне пробування): " + sw.ElapsedTicks);
    }
    // проста хеш-функція
    public static int SimpleHash(string key, int size)
    {
        int sum = 0;
        foreach (char c in key)
        {
            sum += c;
        }
        return sum % size;
    }
}
// хеш таблиця з ланцюжками
class HashTableChaining
{
    private List<string>[] table;
    private int size;

    public HashTableChaining(int size)
    {
        this.size = size;
        table = new List<string>[size];
    }
    public bool Add(string value)
    {
        int index = Program.SimpleHash(value, size);

        if (table[index] == null)
        {
            table[index] = new List<string>();
        }
        if (table[index].Contains(value))
        {
            return false;
        }
        table[index].Add(value);
        return true;
    }
    public bool Contains(string value)
    {
        int index = Program.SimpleHash(value, size);
        if (table[index] == null)
        {
            return false;
        }
        return table[index].Contains(value);
    }
}
// хеш таблиця з лінійним пробуванням 
class HashTableLinearProbing
{
    private string[] table;
    private int size;

    public HashTableLinearProbing(int size)
    {
        this.size = size;
        table = new string[size];
    }
    public bool Add(string value)
    {
        int index = Program.SimpleHash(value, size);
        while (table[index] != null)
        {
            if (table[index] == value)
                return false;

            index = (index + 1) % size;
        }
        table[index] = value;
        return true;
    }
    public bool Contains(string value)
    {
        int index = Program.SimpleHash(value, size);
        while (table[index] != null)
        {
            if (table[index] == value)
                return true;

            index = (index + 1) % size;
        }
        return false;
    }
}

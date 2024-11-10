### 1. **������� (���������) �����**
������� ����� ����� ������� � ������������ � ����� ����� ���������. �� ����� ����� ��������� � ��������� ���� � ������, ������� �������� ����� �������� ����������.

```csharp
public class Car
{
    public string Model { get; set; }
    public int Year { get; set; }

    // ����������� � �����������
    public Car(string model, int year)
    {
        Model = model;
        Year = year;
    }

    // ����� ����������
    public void Drive()
    {
        Console.WriteLine($"{Model} is driving.");
    }
}

// �������������:
Car myCar = new Car("Toyota", 2020);
myCar.Drive(); // �����: Toyota is driving.
```

---

### 2. **����������� �����**
����������� ����� �� ��������� ��������� ���������� � ������������ ��� �������� ����������� ������� � ������, ��������� ��������� � ����������.

```csharp
public static class MathHelper
{
    public static double Pi = 3.14159;

    public static double CalculateCircleArea(double radius)
    {
        return Pi * radius * radius;
    }
}

// �������������:
double area = MathHelper.CalculateCircleArea(5);
Console.WriteLine(area); // �����: 78.53975
```

---

### 3. **Singleton (��������)**
������ �������������� Singleton �����������, ��� ����� ����� ����� ������ ���� ��������� �� ���� ����������. ��� ������� ��� ������ � ������������� ��� ������������, ������� ������ ������������ � ����� ����������.

```csharp
public class Database
{
    private static Database? _instance;
    private static readonly object _lock = new();

    private Database() { } // ��������� �����������

    public static Database Instance
    {
        get
        {
            lock (_lock)
            {
                return _instance ??= new Database();
            }
        }
    }

    public void Connect()
    {
        Console.WriteLine("Connected to database.");
    }
}

// �������������:
Database db = Database.Instance;
db.Connect(); // �����: Connected to database.
```

---

### 4. **����� � ��������������� �������**
������������� �������������� ��������� ������ �������� ������� ����� �������� �������. ��� ��������� �������� �������������� �������������.

```csharp
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
}

// �������������:
Book book = new Book
{
    Title = "C# in Depth",
    Author = "Jon Skeet",
    Pages = 900
};
```

---

### 5. **������������ ����� (Sealed Class)**
������������ ����� ������ �����������. ��� ������� ��� ����������� ������������ � �������������� ��������� ��������� ������.

```csharp
public sealed class Logger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

// �������������:
Logger logger = new Logger();
logger.Log("Logging a message.");
```

---

### 6. **����������� �����**
����������� ����� �� ����� ���� ������ ��������, �� ����� ��������� ��� �������������, ��� � ��������������� (�����������) ������. ������������ ��� ������� ����� ��� ������ �������.

```csharp
public abstract class Animal
{
    public abstract void MakeSound(); // ����������� �����

    public void Sleep()
    {
        Console.WriteLine("Sleeping...");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

// �������������:
Animal animal = new Dog();
animal.MakeSound(); // �����: Woof!
animal.Sleep(); // �����: Sleeping...
```

---

### 7. **����� � ���������� �������� (Partial Class)**
��������� ����� ������ �� ��������� ������. ������ ��� ������� ������� ��� ������������� ����, �������� ��� ������ � ���������� UI.

```csharp
// File1.cs
public partial class Person
{
    public string FirstName { get; set; }
}

// File2.cs
public partial class Person
{
    public string LastName { get; set; }
}

// �������������:
Person person = new Person { FirstName = "John", LastName = "Doe" };
Console.WriteLine($"{person.FirstName} {person.LastName}");
```

---

### 8. **��������� ������**
������ ����� ��������� ������ ������ �������. ��� �������, ���� ��������� ����� ������������ ������ ��� ������������� � ������������ ������.

```csharp
public class OuterClass
{
    public class InnerClass
    {
        public void Display()
        {
            Console.WriteLine("Inner class method");
        }
    }
}

// �������������:
OuterClass.InnerClass inner = new OuterClass.InnerClass();
inner.Display(); // �����: Inner class method
```

---

### 9. **Generic �����**
Generic ������ ��������� ��������� ������, ������� ����� �������� � ����� ����� ������, ����� ��� ����� ������ � �������� ������������.

```csharp
public class Box<T>
{
    public T Item { get; set; }

    public void DisplayItem()
    {
        Console.WriteLine($"Item: {Item}");
    }
}

// �������������:
Box<int> intBox = new Box<int> { Item = 123 };
intBox.DisplayItem(); // �����: Item: 123

Box<string> stringBox = new Box<string> { Item = "Hello" };
stringBox.DisplayItem(); // �����: Item: Hello
```

---

### 10. **����� � ��������� ������� (Factory Pattern)**
������������ ��� �������� ����������� ������� �� ������ ������� ��� ����. ��������� �������� ������ �������� �������� �� �������� ������-������.

```csharp
public class AnimalFactory
{
    public static Animal CreateAnimal(string type)
    {
        return type switch
        {
            "dog" => new Dog(),
            "cat" => new Cat(),
            _ => throw new ArgumentException("Invalid animal type")
        };
    }
}

// �������������:
Animal myDog = AnimalFactory.CreateAnimal("dog");
myDog.MakeSound(); // �����: Woof!
```

---

��� ��������� ��������� �������� ���� ������� � C# � �������� �������������, ��� ������� ������� ���������� ��� � ����������� �� ���� �������.

� ���� ������ ���������� **������ Singleton**, ��� �������� ������ ���� ��������� `HttpServiceSingleton` ��� ����� ����������. �������� ���������, ��� ��� ��������, �������� ����� � `lock` � ������ � `Connect` ����� ���������� ��������.

### 1. ���� `get { lock (_lock) { ... } }`

���� ���� ������������ ��� **����������������� �������** � ���������� ������. 

```csharp
public static HttpServiceSingleton Instance
{
    get
    {
        lock (_lock)
        {
            return _instance ??= new HttpServiceSingleton();
        }
    }
}
```

#### ��� ��� ��������:
- **`lock (_lock)`** � ������ ������� (����������) �� ������� `_lock`, ����������, ��� ������ ���� ����� ����� ��������� ���� `lock` ������������. ��� ������������� ������������� �������� ���������� ����������� `HttpServiceSingleton`, ���� � ���� ���������� �� ���������� �������.
- **`_instance ??= new HttpServiceSingleton()`** � ���������, ���������� �� ��������� `_instance`. ���� �� `null`, �������� ����� ��������� `HttpServiceSingleton` � ������������� `_instance`. � ��������� ������ ������������ ��� ��������� ���������.

#### ������ ������������������ ����� �����:
������������������ �����, ����� �������� �������� ���������� ����������� ������, ���� ������ ������ ������� `Instance` ������������. `lock` �����������, ��� ���� ��� ������������� ������� ����� ������ ������ ���� ��������� ������.

### 2. ����������� ����� `Connect`

����� `Connect` �������� ��� **`static`** � ������� �� ������� ���������� ������ ��� ������. �� ������ ������� ��� �������� ����� `HttpServiceSingleton.Connect(...)`.

```csharp
public static async Task<string> Connect(string baseUri, string? endpoint = null)
{
    _httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(20),
        BaseAddress = new Uri(baseUri)
    };
    // ������ ���������� GET-�������...
}
```

### ������ ����� ���������� � `Connect`, ���� ����� �� �����������

- **����������� ������** ����������� ������, � �� ����������� �������. ���� ���� ��� ����� `HttpServiceSingleton` ���������� ��� Singleton, **Connect** �������� ��� �������� ����������, ��� ��� ����� ������� `static`.
- ������ **����� ��������� ���������� ������ � `_httpClient` � ����������** (�� ���� ������� ����� �������������), ���� ��������� ��������� ��������� ������������ � ������������ ������ ���� ������ ��� ���� �������� � ���� �������.
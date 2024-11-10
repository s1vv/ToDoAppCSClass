### 1. **Обычный (Публичный) Класс**
Обычный класс можно создать и использовать в любом месте программы. Он может иметь публичные и приватные поля и методы, которые доступны после создания экземпляра.

```csharp
public class Car
{
    public string Model { get; set; }
    public int Year { get; set; }

    // Конструктор с параметрами
    public Car(string model, int year)
    {
        Model = model;
        Year = year;
    }

    // Метод экземпляра
    public void Drive()
    {
        Console.WriteLine($"{Model} is driving.");
    }
}

// Использование:
Car myCar = new Car("Toyota", 2020);
myCar.Drive(); // Вывод: Toyota is driving.
```

---

### 2. **Статический Класс**
Статический класс не позволяет создавать экземпляры и используется для хранения статических методов и данных, доступных глобально в приложении.

```csharp
public static class MathHelper
{
    public static double Pi = 3.14159;

    public static double CalculateCircleArea(double radius)
    {
        return Pi * radius * radius;
    }
}

// Использование:
double area = MathHelper.CalculateCircleArea(5);
Console.WriteLine(area); // Вывод: 78.53975
```

---

### 3. **Singleton (Одиночка)**
Шаблон проектирования Singleton гарантирует, что класс будет иметь только один экземпляр во всем приложении. Это полезно для работы с конфигурацией или соединениями, которые должны существовать в одном экземпляре.

```csharp
public class Database
{
    private static Database? _instance;
    private static readonly object _lock = new();

    private Database() { } // Приватный конструктор

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

// Использование:
Database db = Database.Instance;
db.Connect(); // Вывод: Connected to database.
```

---

### 4. **Класс с Инициализатором Объекта**
Использование инициализатора позволяет задать значения свойств после создания объекта. Это позволяет избежать дополнительных конструкторов.

```csharp
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
}

// Использование:
Book book = new Book
{
    Title = "C# in Depth",
    Author = "Jon Skeet",
    Pages = 900
};
```

---

### 5. **Запечатанный Класс (Sealed Class)**
Запечатанный класс нельзя наследовать. Это полезно для обеспечения безопасности и предотвращения изменения поведения класса.

```csharp
public sealed class Logger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

// Использование:
Logger logger = new Logger();
logger.Log("Logging a message.");
```

---

### 6. **Абстрактный Класс**
Абстрактный класс не может быть создан напрямую, но может содержать как реализованные, так и нереализованные (абстрактные) методы. Используется как базовый класс для других классов.

```csharp
public abstract class Animal
{
    public abstract void MakeSound(); // Абстрактный метод

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

// Использование:
Animal animal = new Dog();
animal.MakeSound(); // Вывод: Woof!
animal.Sleep(); // Вывод: Sleeping...
```

---

### 7. **Класс с Частичными Методами (Partial Class)**
Частичный класс разбит на несколько файлов. Удобно для больших классов или автогенерации кода, особенно при работе с дизайнером UI.

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

// Использование:
Person person = new Person { FirstName = "John", LastName = "Doe" };
Console.WriteLine($"{person.FirstName} {person.LastName}");
```

---

### 8. **Вложенные Классы**
Классы можно объявлять внутри других классов. Это полезно, если вложенный класс предназначен только для использования в родительском классе.

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

// Использование:
OuterClass.InnerClass inner = new OuterClass.InnerClass();
inner.Display(); // Вывод: Inner class method
```

---

### 9. **Generic Класс**
Generic классы позволяют создавать классы, которые могут работать с любым типом данных, делая код более гибким и повторно используемым.

```csharp
public class Box<T>
{
    public T Item { get; set; }

    public void DisplayItem()
    {
        Console.WriteLine($"Item: {Item}");
    }
}

// Использование:
Box<int> intBox = new Box<int> { Item = 123 };
intBox.DisplayItem(); // Вывод: Item: 123

Box<string> stringBox = new Box<string> { Item = "Hello" };
stringBox.DisplayItem(); // Вывод: Item: Hello
```

---

### 10. **Класс с Фабричным Методом (Factory Pattern)**
Используется для создания экземпляров классов на основе условий или типа. Позволяет отделить логику создания объектов от основной бизнес-логики.

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

// Использование:
Animal myDog = AnimalFactory.CreateAnimal("dog");
myDog.MakeSound(); // Вывод: Woof!
```

---

Эта шпаргалка покрывает основные типы классов в C# и варианты инициализации, что поможет выбрать подходящий тип в зависимости от нужд проекта.

В этом классе реализован **шаблон Singleton**, где создаётся только один экземпляр `HttpServiceSingleton` для всего приложения. Разберем подробнее, как это работает, особенно блоки с `lock` и почему к `Connect` можно обратиться напрямую.

### 1. Блок `get { lock (_lock) { ... } }`

Этот блок используется для **потокобезопасного доступа** к экземпляру класса. 

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

#### Как это работает:
- **`lock (_lock)`** — создаёт монитор (блокировку) на объекте `_lock`, гарантируя, что только один поток может выполнять блок `lock` одновременно. Это предотвращает одновременное создание нескольких экземпляров `HttpServiceSingleton`, если к нему обращаются из нескольких потоков.
- **`_instance ??= new HttpServiceSingleton()`** — проверяет, существует ли экземпляр `_instance`. Если он `null`, создаётся новый экземпляр `HttpServiceSingleton` и присваивается `_instance`. В противном случае возвращается уже созданный экземпляр.

#### Почему потокобезопасность важна здесь:
Потокобезопасность нужна, чтобы избежать создания нескольких экземпляров класса, если разные потоки вызовут `Instance` одновременно. `lock` гарантирует, что даже при многопоточном доступе будет создан только один экземпляр класса.

### 2. Статический метод `Connect`

Метод `Connect` объявлен как **`static`** и поэтому не требует экземпляра класса для вызова. Вы можете вызвать его напрямую через `HttpServiceSingleton.Connect(...)`.

```csharp
public static async Task<string> Connect(string baseUri, string? endpoint = null)
{
    _httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(20),
        BaseAddress = new Uri(baseUri)
    };
    // Логика выполнения GET-запроса...
}
```

### Почему можно обратиться к `Connect`, хотя класс не статический

- **Статические методы** принадлежат классу, а не конкретному объекту. Даже если сам класс `HttpServiceSingleton` реализован как Singleton, **Connect** доступен без создания экземпляра, так как метод помечен `static`.
- Однако **лучше привязать функционал работы с `_httpClient` к экземпляру** (то есть сделать метод нестатическим), если требуется следовать принципам инкапсуляции и использовать только один клиент для всех операций с этим классом.
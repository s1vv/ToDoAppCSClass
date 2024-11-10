using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoAppCS.HttpClientService;

namespace ToDoAppCS;

class Program
{
    static async Task Main(string[] args)
    {
        HttpService.Initialize("https://jsonplaceholder.typicode.com/todos/");
        var result = await HttpService.GetAsync("1");
        Console.WriteLine(result);

        HttpService.Initialize("https://jsonplaceholder.typicode.com/todos/", proxy: true);
        result = await HttpService.GetAsync("2");
        Console.WriteLine(result);

        HttpServiceSingleton httpServiceSingleton = HttpServiceSingleton.Instance;
        result = await httpServiceSingleton.Connect("https://jsonplaceholder.typicode.com/todos/", "3");
        Console.WriteLine(result);
    }
}

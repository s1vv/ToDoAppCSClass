using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppCS.HttpClientService;

class HttpService
{
    private static HttpClient? _httpClient;

    public static void Initialize(string baseUri, bool proxy=false)
    {
        if (proxy)
        {
            _httpClient = new HttpClient(ProxyHttp.GetProxy())
            {
                Timeout = TimeSpan.FromSeconds(20),
                BaseAddress = new Uri(baseUri)
            };
        }
        else
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(20),
                BaseAddress = new Uri(baseUri)
            };
        }
    }

    public static async Task<string> GetAsync(string endpoint)
    {
        if (_httpClient == null)
            throw new InvalidOperationException("HttpClientService is not initialized. Call Initialize(strin baseUri) first.");

        try
        {
            Console.WriteLine($"Requesting URL: {_httpClient.BaseAddress}{endpoint}");
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            string data = await response.Content.ReadAsStringAsync();
            return data;
        }
        catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return $"Resource not found at {endpoint}";
        }
    }
}

class HttpServiceSingleton
{
    private static HttpServiceSingleton? _instance;
    private static readonly object _lock = new();
    private static HttpClient? _httpClient;


    private HttpServiceSingleton() { }

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

    public async Task<string> Connect(string baseUri, string? endpoint=null)
    {
        _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(20),
            BaseAddress = new Uri(baseUri)
        };

       
        try
        {
            Console.WriteLine($"Requesting URL: {_httpClient.BaseAddress}");
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            string data = await response.Content.ReadAsStringAsync();
            return data;
        }
        catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return $"Resource not found at {endpoint}";
        }
    }
}

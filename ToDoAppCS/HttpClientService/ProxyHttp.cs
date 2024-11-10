using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppCS.HttpClientService;

class ProxyHttp
{
    private static readonly HttpClientHandler _httpClientHandler;

    static ProxyHttp()
    {
        string proxyAddress = "http://85.195.81.170:10086";
        string proxyUser = "bf0Tx7";
        string proxyPassword = "q0chTM";
        var proxy = new WebProxy() 
        {
            Address = new Uri(proxyAddress),
            Credentials = new NetworkCredential(proxyUser, proxyPassword),
            BypassProxyOnLocal = false

        };

        _httpClientHandler = new HttpClientHandler()
        {
            Proxy = proxy,
            UseProxy = true
        };

    }

    public static HttpClientHandler GetProxy()
    {
        return _httpClientHandler;
    }
        
}

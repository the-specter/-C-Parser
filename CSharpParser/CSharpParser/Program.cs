using System;
using System.Net; // Для работы с Интернетом
using System.Threading; // Для многопоточности
using System.Diagnostics; // Для взаимодействия с внешними процесами
using CSharpParser;


namespace CSharpParser
{
    class Program
    {

        static void Main(string[] args)
        {
            WebClient Client = new WebClient();
            Client.Headers.Add("user-agent", Constants.ChromeUserAgent);
            Console.WriteLine("Hello World!");
        }
    }
}

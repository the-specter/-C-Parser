using CSharpParser; // App namespace
using System;
using System.Net; // Для работы с Интернетом
using System.Threading; // Для многопоточности
using System.Diagnostics; // Для взаимодействия с внешними процесами
using System.Text;
using System.IO; // Stream

namespace CSharpParser
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Loading . . .");

            WebClient Client = new WebClient();
            Client.Encoding = Encoding.GetEncoding(Constants.UTF8); // Изменение стандартной кодировки на uft - 8 для отображения русских символов
            Client.Headers.Add("user-agent", Constants.ChromeUserAgent); // User-Agent

            Console.WriteLine("Start download site . . .");
            Stream Site = Client.OpenRead(Constants.Anidub); // Загружает сайт
            StreamReader SiteReader = new StreamReader(Site, Encoding.GetEncoding(Constants.UTF8)); // Считывает сайт
            Console.WriteLine("Download done . . .");

            Console.WriteLine(SiteReader.ReadToEnd()); // Выводит код страницы
            

            Console.ReadKey();
        }
    }
}

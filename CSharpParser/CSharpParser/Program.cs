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
            Console.WriteLine("Загрузка . . .");

            Uri Anidub = new Uri("https://anime.anidub.com/");
            string ChromeUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36";
            string UTF8 = "utf-8";

            WebClient Client = new WebClient();
            Client.Encoding = Encoding.GetEncoding(UTF8); // Изменение стандартной кодировки на uft - 8 для отображения русских символов
            Client.Headers.Add("user-agent", ChromeUserAgent); // User-Agent

            Console.WriteLine("Загрузка сайта . . .");
            Stream Site = Client.OpenRead(Anidub); // Загружает сайт
            StreamReader SiteReader = new StreamReader(Site, Encoding.GetEncoding(UTF8)); // Считывает сайт
            Console.WriteLine("Сайт загружен . . .");

            Console.WriteLine(SiteReader.ReadToEnd()); // Выводит код страницы

            // Закрытие потоков
            Site.Close();
            SiteReader.Close();

            Console.ReadKey(); // Ожидание нажатия клавиши
        }
    }
}
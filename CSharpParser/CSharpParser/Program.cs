using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CSharpParser
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 308; i++)
            {
                WriteLenth(i);
                System.Threading.Thread.Sleep(150);
                //Console.ReadKey();
            }

            //Console.ReadKey();
        }

        public static async void WriteLenth(int i)
        {
            HtmlDocument Document = await GetAnidubSourceCodeAsync("page/" + i.ToString() + "/"); 
            HtmlNodeCollection AnimeShortInfo = Document.DocumentNode.SelectNodes("//div[@class='news_short']/div[@class='newsfoot']/span/a");
            for (int j = 0; j < 9; j++)
            {
                string s = AnimeShortInfo[j].Attributes["title"].Value.Replace("Смотреть ", "");
                string end = "";
                foreach (char sym in s)
                {
                    if (sym != '/')
                        end += sym;
                    else
                        break;
                }
                Console.WriteLine( end );
            }

        }

        public static async Task<HtmlDocument> GetAnidubSourceCodeAsync(string prefix)
        {
            var Anidub = new Uri("https://online.anidub.com/" + prefix);
            var Client = new HttpClient();
            var SourceCode = await Client.GetStringAsync(Anidub);

            var Document = new HtmlDocument();
            Document.LoadHtml(SourceCode);

            return Document;
        }
    }

}
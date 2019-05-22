using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace CSharpParser
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 310; i++)
            {
                WriteLenth(i);
                System.Threading.Thread.Sleep(150);
            }

            Console.ReadKey();
        }

        public static async void WriteLenth(int page)
        {
            HtmlDocument Document = await GetAnidubSourceCodeAsync("page/" + page.ToString() + "/");
            HtmlNodeCollection AnimeHeaders = Document.DocumentNode.SelectNodes("//div[@id='dle-content']/div[@class='newstitle']//a[@itemprop='name']");
            HtmlNodeCollection AnimeDescriptions = Document.DocumentNode.SelectNodes("//div[@id='dle-content']/div[@class='news_short']//div[@class='maincont']//div[@style='display:inline;']");
            HtmlNodeCollection AnimeURLs = Document.DocumentNode.SelectNodes("//div[@id='dle-content']/div[@class='news_short']//span[@class='newsmore']");
            System.Threading.Thread.Sleep(20);
            var SizeMas = AnimeHeaders.ToArray();
            for (int i = 0; i < SizeMas.Length; i++)
            {
                var AnimeName = HttpUtility.HtmlDecode(AnimeHeaders[i].InnerText);
                var AnimeURL = HttpUtility.HtmlDecode(AnimeURLs[i].SelectSingleNode("./a").Attributes["href"].Value);
                var AnimeDescription = HttpUtility.HtmlDecode(AnimeDescriptions[i].InnerText);

                string exitLine = "";
                foreach (char sym in AnimeName)
                {
                    if (sym != '/')
                        exitLine += sym;
                    else
                        break;
                }
                AnimeName = exitLine;

                Console.WriteLine("---------------\n" + AnimeName);
                Console.WriteLine(AnimeURL);
                Console.WriteLine("\n" + AnimeDescription + "\n");
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
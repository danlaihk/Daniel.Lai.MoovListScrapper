using System.Text;

namespace Daniel.Lai.MoovListScrapper;

class Program
{
    
    static void Main(string[] args)
    {

        Console.OutputEncoding = Encoding.Unicode;  // For UTF-16

        Console.WriteLine("Please enter your song list url");
        var url = Console.ReadLine();
        //https://s.moov.hk/r?s=xxxxx
        if (string.IsNullOrWhiteSpace(url))
        {
            Console.WriteLine("Empty song list url");
            return;
        }
        
        Console.WriteLine("Please enter your file path");
        var filepath = Console.ReadLine();  
        //for example D:\test.csv
        if (string.IsNullOrWhiteSpace(filepath))
        {
            Console.WriteLine("Empty song list url");
            return;
        }
        else if(File.Exists(filepath))
        {
            Console.WriteLine($"File exists in path {filepath}");
            return;
        }

        
        
        
        Console.WriteLine($"Your url is: {url}");
        Console.WriteLine($"Start Scrapping....");
        var service = new ScrapperService();
        var songList = service.GetSongList(url);
        
        var csvString = new StringBuilder();
        foreach (var song in songList)
        {
            csvString.AppendLine($"{song.Name},{song.Artist}");
        }

        
        File.WriteAllText(filepath, csvString.ToString());
        Console.WriteLine("Scrapping is done.");
        Console.ReadKey();
    }
}
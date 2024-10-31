using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace Daniel.Lai.MoovListScrapper;

public class ScrapperService
{
    private readonly IWebDriver _drive = new EdgeDriver();

    public List<Song> GetSongList(string url)
    {
        
        _drive.Navigate().GoToUrl(url);
        _drive.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        
        
        var songs = new List<Song>();
        
        //get the song list table
        var listElement = _drive.FindElement(By.ClassName("moduleList"));
   
        //get the rows
        var rows = listElement.FindElements(By.CssSelector(".l-r "));
        
        foreach (var rowElement in rows)
        {
            var songCol = rowElement.FindElement(By.CssSelector("div.song"));
            var artistCol = rowElement.FindElement(By.CssSelector("div.artist"));
            
            songs.Add(new Song
            {
                Name = songCol?.Text ?? string.Empty,
                Artist = artistCol?.Text ?? string.Empty,
            });
        }
        return songs;
        
    }
}
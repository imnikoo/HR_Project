using BotDomain.Entities;
using BotDomain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotData.Dictionary
{
    public static class Dictionary
    {
        public static List<Country> Countries = new List<Country>
        {
            new Country { EditTime=DateTime.Now, Name="Ukraine" }
        };
        public static List<City> Cities = new List<City>
        {
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Kiev" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Kharkiv" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Odessa" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Dnipropetrovsk" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Zaporizhia" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Lviv" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Kryvyi Rih" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Mykolaiv" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Mariupol" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Luhansk" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Donetsk" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Sevastopol" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Vinnytsia" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Makiivka" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Simferopol" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Kherson" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Poltava" },
            new City { EditTime = DateTime.Now, Country=Countries[0], Name="Chernihiv" },
        };
        public static List<Stage> Stages = new List<Stage>
        {
            new Stage { EditTime = DateTime.Now, Title="Pool", Description="" },
            new Stage { EditTime = DateTime.Now, Title="Selected", Description="" },
            new Stage { EditTime = DateTime.Now, Title="HR Interview", Description="" },
            new Stage { EditTime = DateTime.Now, Title="Test task", Description="" },
            new Stage { EditTime = DateTime.Now, Title="Tech Interview", Description="" },
            new Stage { EditTime = DateTime.Now, Title="Additional interview", Description="" },
            new Stage { EditTime = DateTime.Now, Title="Final Interview", Description="" },
            new Stage { EditTime = DateTime.Now, Title="Job Offer Issued", Description="" },
            new Stage { EditTime = DateTime.Now, Title="Job Offer Accepted", Description="" },
            new Stage { EditTime = DateTime.Now, Title="Hired", Description="" },
            new Stage { EditTime = DateTime.Now, Title="Rejected", Description="" },
        };
    }
}

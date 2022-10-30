using AAAA4.Models;

namespace AAAA4.Managers
{
    public class FootballplayersManger
    {
        private static int _nextId = 1;

        private static readonly List<Footballplayer> Data = new List<Footballplayer>
        {
            new Footballplayer {Id = _nextId++,Name = "alisina", age = 30, ShirtNumber = 10},
            new Footballplayer {Id = _nextId++,Name = "alix", age = 31, ShirtNumber = 11},
            new Footballplayer {Id=_nextId++, Name = "Subhan", age = 25, ShirtNumber = 9},
            new Footballplayer {Id = _nextId++,Name = " shan", age = 20, ShirtNumber = 17},
           
  
        };
        public List<Footballplayer> GetAll()
        {
            return new List<Footballplayer>(Data);
            
        }
        public Footballplayer GetById(int id)
        {
            return Data.Find(Footballplayer => Footballplayer.Id == id);
        }


        public Footballplayer Add(Footballplayer newFootballplayer)
        {
            newFootballplayer.Id = _nextId++;
            Data.Add(newFootballplayer);
            return newFootballplayer;
        }
        public Footballplayer Delete(int id)
        {
            Footballplayer footballplayer = Data.Find(footballplayer1 => footballplayer1.Id == id);
            if (footballplayer == null) return null;
            Data.Remove(footballplayer);
            return footballplayer;
        }

        public Footballplayer Update(int id, Footballplayer updates)
        {
            Footballplayer footballplayer = Data.Find(footballplayer1 => footballplayer1.Id == id);
            if (footballplayer == null) return null;
            footballplayer.Name = updates.Name;
            footballplayer.age = updates.age;
            footballplayer.ShirtNumber = updates.ShirtNumber;
            footballplayer.Id = updates.Id;
            return footballplayer;
        }

    }
}

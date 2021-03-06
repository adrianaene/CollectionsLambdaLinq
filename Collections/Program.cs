﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Collections.Collection;
using Collections.Enumerable;
using Collections.List;

namespace Collections
{
    class Program
    {
        private static List<Band> bands = new List<Band>();
        private static readonly Band[] BandsArray =
        {
            new Band("Led Zeppelin", 9, "Hard Rock", "England"),
            new Band("Judas Priest", 17, "Heavy Metal", "England"),
            new Band("Phoenix", 10, "Rock", "Romania"),
            new Band("Black Sabbath", 19, "Heavy Metal", "England"),
            new Band("Rammstein", 6, "Industrial Metal", "Germany"),
            new Band("Black Keys", 8, "Indie Rock", "United States"),
            new Band("Muse", 6, "Alternative Rock", "England")
        };

        static void Main(string[] args)
        {
           // EnumerableExample();
            //YieldExample();
           // CollectionExample();
           // ListExample();
            //DictionaryExample();

            //afisare folosind indexer
            
            for (int i = 0; i < BandsArray.Count(); i++)
                Console.WriteLine(BandsArray[i].Name + " " + BandsArray[i].StudioAlbums + " " + BandsArray[i].Genre + " " + BandsArray[i].Country);
            Console.WriteLine();
            // populare List<Band>
            bands.Add(new Band("Led Zeppelin", 9, "Hard Rock", "England"));
            bands.Add(new Band("Judas Priest", 17, "Heavy Metal", "England"));
            bands.Add(new Band("Phoenix", 10, "Rock", "Romania"));
            bands.Add(new Band("Black Sabbath", 19, "Heavy Metal", "England"));
            bands.Add(new Band("Rammstein", 6, "Industrial Metal", "Germany"));
            bands.Add(new Band("Black Keys", 8, "Indie Rock", "United States"));
            bands.Add(new Band("Muse", 6, "Alternative Rock", "England"));

            // se sorteaza in functie de numarul de albume
            bands.Sort();
            foreach(Band band in bands)
                 Console.WriteLine("{0}   {1}   {2}   {3} ", band.Name, band.Genre, band.Country, band.StudioAlbums);
            Console.Read();
         
        }

        private static void EnumerableExample()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------Enumerable Example-----------------------------");

            //Enumerating example
            var bands = new BandsEnumerable(BandsArray);
            var enumerator = bands.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var band = enumerator.Current;
                Console.WriteLine("{0} ({1}, {2}): {3} albums.", band.Name, band.Genre, band.Country, band.StudioAlbums);
            }

            //TODO 1: Change "BandsEnumerator" to enumerate from last element to first.
        }

        private static void YieldExample()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------Yield Example-----------------------------");

            //Enumerating an yield list
            foreach (var frontman in FrontmenList())
            {
                Console.WriteLine(frontman);
            }

            Console.WriteLine();

            //Projecting objects in a different form using yield
            var bandNames = BandNames(new List<Band>(BandsArray));
            foreach (var bandName in bandNames)
            {
                Console.WriteLine(bandName);
            }

            Console.WriteLine();

            //TODO 2: Implement "BritishBands" to return only bands that have Country == "England". 
            var britishBands = BritishBands(new List<Band>(BandsArray));
            foreach (var britishBand in britishBands)
            {
                Console.WriteLine(britishBand.Name);
            }
        }

        private static void CollectionExample()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------Collection Example-----------------------------");

            var bandsCollection = new BandsCollection(BandsArray);

            //Custom insert example
            bandsCollection.Insert(0, new Band("Guta", 0, "", ""));
            bandsCollection.Insert(3, new Band("Salam", 0, "", ""));
            bandsCollection.Insert(9, new Band("Susanu", 0, "", ""));

            //Custom item set example
            bandsCollection[3] = new Band("Romeo Fantastik", 0, "", "");

            //Custom remove example
            bandsCollection.RemoveAt(8);

            Console.WriteLine();

            foreach (var bandName in BandNames(bandsCollection))
            {
                Console.WriteLine(bandName);
            }

            //TODO 3: Update bandsCollection.Clear() so it prints the removed items.
        }

        private static void ListExample()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------List Example-----------------------------");

            var bandsList = new List<Band>(BandsArray);

            //Custom comparer example
           // bandsList.Sort(new BasicBandsComparer());
            bandsList.Sort(new CustomBandsComparer(BandsCompareBy.NameLength));
            //bandsList.Sort(new CustomBandsComparer(BandsCompareBy.Name));
            //bandsList.Sort(new CustomBandsComparer(BandsCompareBy.AlbumCount));

            var index = 0;
            foreach (var band in bandsList)
            {
                Console.WriteLine("{0} {1} {2} {3}", index, band.Name, band.StudioAlbums, band.Country);
                index++;
            }

            Console.WriteLine();

            //Add/Get range example
            var bandsToAdd = new[]
            {
                new Band("Guta", 0, "", ""),
                new Band("Salam", 0, "", "")
            };
            bandsList.AddRange(bandsToAdd);
            var lastTwoBands = bandsList.GetRange(bandsList.Count - 2, 2);

            foreach (var bandName in BandNames(lastTwoBands))
            {
                Console.WriteLine(bandName);
            }

            Console.WriteLine();

            //IndexOf uses Object.GetHashCode, which is a reference comparer by default
            var indexNewGuta = bandsList.IndexOf(new Band("Guta", 0, "", ""));
            Console.WriteLine("Index of new Guta is {0}", indexNewGuta);
            var indexRefGuta = bandsList.IndexOf(bandsToAdd[0]);
            Console.WriteLine("Index of reference Guta is {0}", indexRefGuta);

            //TODO 4: Extend CustomBandsComparer to allow comapring by name length.
        }

        private static void DictionaryExample()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------Dictionary Example-----------------------------");

            //Adding items example
            var bandsDictionary = new Dictionary<string, Band>();
            foreach (var band in BandsArray)
            {
                bandsDictionary.Add(band.Name, band);
            }

            //Enumerating the KeyValue pairs
            foreach (var keyValuePair in bandsDictionary)
            {
                //TODO 5: Change to display key and albums count
                Console.WriteLine("Key: {0}, Value: {1}", keyValuePair.Key, keyValuePair.Value);
            }

            Console.WriteLine();

            //Retrieving value based on key example
            var bandToGet = bandsDictionary["Muse"];
            Console.WriteLine("{0} {1} {2}", bandToGet.Name, bandToGet.Genre, bandToGet.Country);

            Console.WriteLine();

            //TODO 7: Check if key is present before adding/retrieving a new entry.
          if(!bandsDictionary.ContainsKey("Muse"))
            bandsDictionary.Add("Muse", new Band("Muse", 6, "Alternative Rock", "England"));
            //Console.WriteLine(bandsDictionary["Guta"].Name);
        }

        private static IEnumerable<string> FrontmenList()
        {
            yield return "Robert Plant";
            yield return "Rob Halford";
            yield return "Nicu Covaci";
            yield return "Ozzy Osbourne";
            yield return "Till Lindemann";
            yield return "Dan Auerbach";
            yield return "Matt Bellamy";
        }

        private static IEnumerable<string> BandNames(IEnumerable<Band> bandsList)
        {
            int index = 0;
            foreach (var band in bandsList)
            {
                yield return index + " " + band.Name;
                index++;
            }
        }

        private static IEnumerable<Band> BritishBands(IEnumerable<Band> bandsList)
        {
            foreach (Band b in bandsList)
            {
                if(b.Country == "England")
                    yield return b;
            }
            
        }

    }
}

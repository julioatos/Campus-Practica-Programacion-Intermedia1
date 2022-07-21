using System;
using System.Text.RegularExpressions;

namespace Campus_Practica_Programacion_Intermedia1
{
    internal abstract class Pair
    {
        public abstract string Key { get; set; }
        public abstract dynamic Value { get; set; }
    }

    internal class Map<TPair> where TPair : Pair
    {
        private TPair[] _pairs = new TPair[100];

        public void Put(int i, TPair t)
        {
            _pairs[i] = t;
        }

        public TPair GetAt(int i)
        {
            return _pairs[i];
        }

        public TPair Get(string key)
        {
            foreach (TPair pair in _pairs)
            {
                if (pair != null && pair.Key == key)
                    return pair;
            }

            throw new Exception("Key not found!");
        }

        

    }

    internal class MyPairs : Pair
    {

        public override string Key { get; set; }
        public override dynamic Value { get; set; }
        public MyPairs(string key, dynamic value) 
        {
          
            Key = key;
            Value = value;
        }
    }

    static class ExtensiveMethod
    {
        public static T GetFirst<T>(this Map<T> map) where T : Pair
        {
            return map.GetAt(0);
        }
        public static bool MatchesPattern(this string str)
        {
            return Regex.IsMatch(str, @"^[A-Z][a-z]{3}\d{4}");
        }
    }
    internal class Program
    {
     
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // Operador ternario
            Console.WriteLine("Operador ternario: ");
            int random = new Random().Next(0, 999);
            string mensaje = random > 500 ? "Greater than 500" : "Less than 500";
            Console.WriteLine(mensaje + "\n");

            // Excepciones y nullables:
            Console.WriteLine("Excepciones y Nullables: ");
            try
            {
                int? numero = null;
                if (numero == null) throw new MyOwnNullReferenceException();
            }
            catch(MyOwnNullReferenceException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            // tipos anonimos y dinamicos
            Console.WriteLine("\nTipos Anonimos: ");
            var book = new
            {
                title = "Gone Girl",
                author = "Gillian Flynn"
            };

            Console.WriteLine("Book title: " + book.title);
            Console.WriteLine("Book author: " + book.author);

            Console.WriteLine("\nTipos dinamicos: ");
            dynamic whatever = 20;
            Console.WriteLine(whatever);

            whatever = "blabla";

            Console.WriteLine(whatever);

            whatever = new { Band = "The Cranberries", Song = "Zombie", Year = 1992 };

            Console.WriteLine(whatever);
            Console.WriteLine();
            Console.WriteLine("Generics: ");

            var map = new Map<MyPairs>();

            map.Put(0, new MyPairs("Paramore", "Decode"));
            map.Put(1, new MyPairs("Linkin Park", "Crawling"));



            try
            {
                var pair1 = map.Get("Paramore");
                var pair2 = map.Get("Linkin Park");
                Console.WriteLine(pair1.Key + ", " + pair1.Value);
                Console.WriteLine(pair2.Key + ", " + pair2.Value);

                Console.WriteLine(map.GetFirst().Key);
                Console.WriteLine(map.GetFirst().Value);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            Console.WriteLine();
            // Regex
            Console.WriteLine("Regex:");
            string text = "Blue5432";
            Console.WriteLine(text.MatchesPattern());


        }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Module13_Practice_2
{
    public class Program
    {
        public static string GetAllTextFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return new string(sr.ReadToEnd().Where(c => !char.IsPunctuation(c)).ToArray()).ToLower();
            }
        }
        public static List<string> StrToListOfWords(string text)
        {
            return new List<string>(text.Split(' ', '\n', '\t'));
        }
        public static Dictionary<string, int> CreateDictionary(IList<string> list)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < list.Count; ++i)
            {
                if (!dict.TryAdd(list[i], 1))
                    dict[list[i]]++;
            }
            dict.Remove(string.Empty);
            return dict;
        }
        public static string[] GetMaxWordsFromDictionary(IDictionary<string, int> dict)
        {
            string[] topWords = new string[10];
            string str = string.Empty;
            for (int i = 0; i < topWords.Length; ++i)
            {
                topWords[i] = dict.MaxBy(x => x.Value).Key;
                dict.Remove(topWords[i]);
            }
            return topWords;
        }
        public static void DisplayCollection<T>(IEnumerable<T> values)
        {
            foreach (var word in values)
                Console.WriteLine(word);
            return;
        }
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Никита\\source\\repos\\Module13_Practice_2\\Module13_Practice_2\\bin\\Debug\\net7.0\\Text1.txt";
            //path = Console.ReadLine();
            string text = GetAllTextFromFile(path);

            List<string> list = StrToListOfWords(text);

            Dictionary<string, int> dict = CreateDictionary(list);

            string[] topWords = GetMaxWordsFromDictionary(dict);

            DisplayCollection(topWords);
            Console.ReadKey();
        }
    }
}
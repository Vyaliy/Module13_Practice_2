using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Module13_Practice_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Никита\\source\\repos\\Module13_Practice_2\\Module13_Practice_2\\bin\\Debug\\net7.0\\Text1.txt";
            //path = Console.ReadLine();
            List<string> list;
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd().ToLower();
            }
            text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            list = new List<string>(text.Split(' ', '\n', '\t'));
            list = new List<string>(list.Where(str => !(string.Empty == str)));
            HashSet<string> hs = new HashSet<string>(list);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            KeyValuePair<string, int> maxInDict;
            string[] topWords = new string[10];
            foreach (var item in hs)
            {
                dict.Add(item, list.Count(str => str == item));
            }
            string str = string.Empty;
            for (int i = 0; i < topWords.Length; ++i)
            {
                topWords[i] = dict.MaxBy(x => x.Value).Key;
                dict.Remove(topWords[i]);
            }
            foreach (var word in topWords)
                Console.WriteLine(word);
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            subClass newClass = new subClass();
            newClass.printHi();

            Console.WriteLine($"Unique of the word \"AAAaaaaabbccccaabcccadsbbbeb\" : {getUniqueInList("AAAaaaaabbccccaabcccadsbbbeb")}");
            Console.WriteLine($"Number of words in \"Pumpkin pies are delicious!\" are: {ammountOfWords("Pumpkin pies are delicious")}");
            Console.WriteLine(ammountOfWords("Hello World"));
            Console.WriteLine(ammountOfWords("There output should be 5!"));
            Console.WriteLine(ammountOfWordsList("Her er det 6 ord til"));

            Console.WriteLine(replaceSpace("ali elhatri @hotmail.com", "_"));
            Console.WriteLine($"Removing duplicate characters from the word albakolskfjowdf: {removeDuplicatesInString("albakolskfjowdf")}");

            string text1 = "Leap";
            string text2 = "Pwal";

            Console.WriteLine(anagramCheck(text1, text2) ? $"{text1} and {text2} are anagrams of eachother" : $"{text1} and {text2} are not anagrams of eachother");

            List<int> listOfNumbers = new List<int>() { 1,2,3,4,2,2,3,4,5,2,3,7,5,5,5,5,8,5,3,8,9};
            StringBuilder listToString = new StringBuilder();
            foreach (int number in listOfNumbers)
            {
                listToString.Append(number);
            }

            Tuple<int, int> mostFrequency = getMostFrequent(listOfNumbers);
            Console.WriteLine($"The most frequent number in the list contatining these numbers: {listToString} is the following:\nNumber: {mostFrequency.Item1}\nAmmount of time occured in the list: {mostFrequency.Item2}");
        }

        static string getUniqueInString(string text)
        {
            StringBuilder stringOfUnique = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (!stringOfUnique.ToString().ToLower().Contains(text[i].ToString().ToLower()))
                {
                    stringOfUnique.Append(text[i]);
                }
            }

            return stringOfUnique.ToString();

        }

        static public int ammountOfWords(string text)
        {
            int words = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == " " || i + 1 == text.Length)
                {
                    words++;
                }
            }
            return words;
        }
        static public int ammountOfWordsList(string text)
        {

            string[] words = text.Split(" ");
            return words.Length;
        }
        static List<char> getUniqueInList(string text)
        {
            List<char> listOfUnique = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!
                    listOfUnique.Contains(text[i]))
                {
                    listOfUnique.Add(text[i]);
                }
            }

            return listOfUnique;

        }
        static string replaceSpace(string text, string whatToReaplceWith)
        {
            return text.Replace(" ", whatToReaplceWith);
        }
        static string removeDuplicatesInString(string text)
        {
            StringBuilder newText = new StringBuilder();
            foreach (char c in text)
            {
                if (!newText.ToString().Contains(c))
                {
                    newText.Append(c);
                }
            }
            return newText.ToString();
        }

        static bool anagramCheck(string text1, string text2)
        {
            if (text1.Length == text2.Length)
            {
                List<char> text1Characters = new List<char>(text1.ToLower().ToCharArray());
                List<char> text2Characters = new List<char>(text2.ToLower().ToCharArray());

                text1Characters.Sort();
                text2Characters.Sort();

                for (int i = 0; i < text1Characters.Count; i++)
                {
                    if(text1Characters[i] != text2Characters[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        static Tuple<int,int> getMostFrequent(List<int> listOfInt)
        {
            int mostFrequent = 0;
            int valueOfFrequent = -1;
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            for(int i = 0; i < listOfInt.Count; i++)
            {
                if(!frequency.ContainsKey(listOfInt[i]))
                {
                    frequency.Add(listOfInt[i], 1);
                }
                else
                {
                    frequency[listOfInt[i]]++;
                }
            }

            foreach(KeyValuePair<int,int> entry in frequency)
            {
                if(entry.Value > mostFrequent)
                {
                    mostFrequent = entry.Value;
                    valueOfFrequent = entry.Key;
                }
            }

            return new Tuple<int, int>(valueOfFrequent, mostFrequent);

        }
    }

    class subClass : mainclass
    {
        public override void printHi()
        {
            Console.WriteLine("Hello from the subclass!");
        }
    }

    abstract class mainclass
    {
        public abstract void printHi();
    }
}

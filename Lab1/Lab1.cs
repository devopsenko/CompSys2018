using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace cslab1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double entropy = 0;//entropy
            double fileinfo = 0.0;//info quantity

            string path = @"E:\Igor\katBase64bz2.txt";

            string text = "";
            double len = 0.0;

            //Console.InputEncoding = Encoding.UTF8;
            //Console.OutputEncoding = Encoding.UTF8;

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                text = sr.ReadToEnd();
                sr.Close();
            }

            //text = File.ReadAllText(path, Encoding.Unicode);
           // Console.WriteLine(text);

            len = text.Length;

            Dictionary<char, int> pair = new Dictionary<char, int>();

            foreach (char ch in text)
            {
                if (pair.ContainsKey(ch))
                    pair[ch] += 1;
                else
                    pair.Add(ch, 1);
            }

            foreach (KeyValuePair<char, int> kvp in pair)
            {
                entropy -= (kvp.Value / len) * Math.Log(kvp.Value / len, 2);
                Console.WriteLine("Symbol: " + kvp.Key + " Frequency: " + kvp.Value + " Probability: " + kvp.Value / len);
            }

            fileinfo = entropy * len / 8;
            Console.WriteLine("Entropy bit: " + entropy + "\n" + "Info quantity byte: " + fileinfo);
            FileInfo file = new FileInfo(path);
            Console.WriteLine("File name: " + file.Name + " File size byte: " + file.Length);
            Console.ReadKey();
        }
    }
}
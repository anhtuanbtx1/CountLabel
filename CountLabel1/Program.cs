using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CountLabel
{
    public class Program
    {
        private static IConfiguration _configuration;
        public static void Main(string[] args)
        {
          
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
            var path = _configuration.GetSection("Name").Value;
            var className = _configuration.GetSection("Class").Value;
            Dictionary<int, string> MyDict = new Dictionary<int, string>();
            MyDict.Add(0, "0");
            MyDict.Add(1, "1");
            MyDict.Add(2, "2");
            MyDict.Add(3, "3");
            MyDict.Add(4, "4");
            MyDict.Add(5, "5");
            MyDict.Add(6, "6");
            MyDict.Add(7, "7");
            MyDict.Add(8, "8");
            MyDict.Add(9, "9");
            MyDict.Add(10, "Q");
            MyDict.Add(11, "W");
            MyDict.Add(12, "E");
            MyDict.Add(13, "R");
            MyDict.Add(14, "T");
            MyDict.Add(15, "Y");
            MyDict.Add(16, "U");
            MyDict.Add(17, "I");
            MyDict.Add(18, "O");
            MyDict.Add(19, "P");
            MyDict.Add(20, "A");
            MyDict.Add(21, "S");
            MyDict.Add(22, "D");
            MyDict.Add(23, "F");
            MyDict.Add(24, "G");
            MyDict.Add(25, "H");
            MyDict.Add(26, "J");
            MyDict.Add(27, "K");
            MyDict.Add(28, "L");
            MyDict.Add(29, "Z");
            MyDict.Add(30, "X");
            MyDict.Add(31, "C");
            MyDict.Add(32, "V");
            MyDict.Add(33, "B");
            MyDict.Add(34, "N");
            MyDict.Add(35, "M");
            Dictionary<int, int> classes = new Dictionary<int, int>();
            classes.Add(0, 0);
            classes.Add(1, 0);
            classes.Add(2, 0);
            classes.Add(3, 0);
            classes.Add(4, 0);
            classes.Add(5, 0);
            classes.Add(6, 0);
            classes.Add(7, 0);
            classes.Add(8, 0);
            classes.Add(9, 0);
            classes.Add(10,0);
            classes.Add(11,0);
            classes.Add(12,0);
            classes.Add(13,0);
            classes.Add(14,0);
            classes.Add(15,0);
            classes.Add(16,0);
            classes.Add(17,0);
            classes.Add(18,0);
            classes.Add(19,0);
            classes.Add(20,0);
            classes.Add(21,0);
            classes.Add(22,0);
            classes.Add(23,0);
            classes.Add(24,0);
            classes.Add(25,0);
            classes.Add(26,0);
            classes.Add(27,0);
            classes.Add(28,0);
            classes.Add(29,0);
            classes.Add(30,0);
            classes.Add(31,0);
            classes.Add(32,0);
            classes.Add(33,0);
            classes.Add(34,0);
            classes.Add(35,0);
            foreach (string txtName in Directory.GetFiles(@$"{path}", "*.txt"))
            {
                var source = File.ReadAllLines(txtName);

                for (int i = 0; i < source.Length; i++)
                {
                    string[] str = source[i].Split('\t');
                    try
                    {
                        int classItem = int.Parse(str[0].ToString().Substring(0, 2));
                        if (classes.ContainsKey(classItem))
                        {
                            classes[classItem]++;
                        }
                        else
                        {
                            Console.WriteLine($"Fail class in range {txtName}");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            foreach (var keyPair in classes)
            {
                Console.WriteLine(string.Format("Character {0} count {1}", MyDict[keyPair.Key], keyPair.Value));
            }
            int mode;
            Console.WriteLine("Changed mode replace class press 1, exit press 2");
            mode = int.Parse(Console.ReadLine());
            if(mode == 1)
            {
                ChangedCharacter();
            }
            else
            Console.ReadKey();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {
               services.AddHostedService<Worker>();
           });
        public static void ChangedCharacter()
        {
            int a = 0;
            do
            {
                int numA;
                int numB;
                Console.Write("Input need to change : ");
                numA = int.Parse(Console.ReadLine());
                Console.Write("Input is changed : ");
                numB = int.Parse(Console.ReadLine());
                var path = _configuration.GetSection("Name").Value;
                //var numBefore = _configuration.GetSection("NumberBefore").Value;
                //var numAfter = _configuration.GetSection("NumberAfter").Value;

                foreach (string txtName in Directory.GetFiles(@$"{path}", "*.txt"))
                {
                    var source = File.ReadAllLines(txtName);

                    for (int i = 0; i < source.Length; i++)
                    {
                        string[] str = source[i].Split('\t');
                        try
                        {
                            int classItemB = int.Parse(str[0].ToString().Substring(0, 2));
                            if (classItemB == numA)
                            {
                                int classItemA = numB;
                                string line = str[0].ToString();
                                var lineNew = line.Replace($"{classItemB}", $"{classItemA}");
                                source[i] = lineNew;
                                File.WriteAllLines(@$"{txtName}", source);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                Console.Write("Continue replace press 1, exit press 2 : ");
                a = int.Parse(Console.ReadLine());
            }
            while (a == 1);
        }
    }

   
}



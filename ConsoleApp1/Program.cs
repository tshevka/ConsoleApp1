using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace ConsoleApp1
{

    struct Cloth
    {
        public string pants;
        public string coat;
        public string dress;
        public string skirt;
        public int price;
        public string size;
        public int height;
        public int age;

    }

    class Cloth 
    {
        List<Cloth> cloth;
        string filename = @"D:\exam.txt";
        public Cloth (string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }
            filename = file;
            cloth = new List<Cloth>();
            LoadFile();
        }
        private void LoadFile()
        {
            string [] words = File.ReadAllText(@filename).Split(' ');
            for(int i = 0; i < words.Length; i++)
            {
                cloth.Add(new Cloth
                {
                    pants = words[i++],
                    coat = words[i++],
                    dress = words[i++],
                    skirt = words[i++],
                    price = Convert.ToInt32(words[i++]),
                    size = Convert.ToChar(words[i++]),
                    height = Convert.ToInt32(words[i++]),
                    age = Convert.ToInt32(words[i++]),
                });
            }
        }

        public void runMenu()
        {
            cloth = cloth.ToList();
            foreach(Cloth cl in cloth)
            {
               
                if (age <=10 && price <=900 && height <150)
                {
                    double averageprice = (Convert.ToInt32(Convert.ToString(cl.pants)) + Convert.ToInt32(Convert.ToString(cl.coat))) / 2;
                    Console.WriteLine("Середня вартість штанів і пальт,за ціною не перевищує 900 грн та зріст до 150 см {0}", string.Format("{0:0.##}",averageprice);

                }
                if (age <= 10) Console.WriteLine("Одяг, що придатний дітям до 10 років {0} {1} {2} {3}", Convert.ToString(cl.pants), Convert.ToString(cl.dress), Convert.ToString(cl.coat), Convert.ToString(cl.skirt));
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
           
            Cloth cl = new Cloth("exam.txt");
            cl.runMenu();
        }
    }
}

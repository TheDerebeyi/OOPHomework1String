using System;

namespace OOPHomework1String
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }

        static void Menu()
        {
            string cache;

            do
            {
                Console.Write("\n\tMenü\n\n" +
                              "1- String bir değişkende, string değeri substring kullanmadan ara.\n" +
                              "2- String bir değişkende, string değeri substring kullanarak ara.\n" +
                              "3- Alfabenin karakterleri bir string içerisinde kaç kere geçiyor bul ve çiz.\n\n" +
                              "Seçiminiz: ");
                cache = Console.ReadLine();
            } while (cache != "1" && cache != "2" && cache != "3");

            switch (cache)
            {
                case "1":
                    Choice1();
                    break;
                case "2":
                    Choice2();
                    break;
                case "3":
                    Choice3();
                    break;
            }
        }

        static void Choice1()
        {
            Console.Write("\nAranılacak kelime: ");
            string stringToSearch = Console.ReadLine();
            Console.Write("Karakter Dizini: ");
            string baseString = Console.ReadLine();

            int index = 0;

            do
            {
               index = baseString.IndexOf(stringToSearch, index);
               if (index == -1)
                   return;
               Console.WriteLine("Kelime C# indis: " + index);
               index++;
            } while (true);

        }

        static void Choice2()
        {
            Console.Write("\nAranılacak kelime: ");
            string stringToSearch = Console.ReadLine();
            Console.Write("Karakter Dizini: ");
            string baseString = Console.ReadLine();

            for (int i = 0; i < baseString.Length - stringToSearch.Length + 1; i++)
            {
                if (baseString.Substring(i, stringToSearch.Length) == stringToSearch)
                {
                    Console.WriteLine("Kelime C# indis: " + i);
                }
            }
        }

        static void Choice3()
        {
            Console.Write("Karakter Dizini: ");
            string baseString = Console.ReadLine();

            string upperString = baseString.ToUpper();

            int[] countByChar = new int[26];

            for (int i = 0; i < 26; i++)
            {
                countByChar[i] = 0;
            }

            for (int i = 0; i < upperString.Length; i++)
            {
                if ((int)upperString[i] > 64 && (int)upperString[i] < 96)
                {
                    countByChar[upperString[i] - 65]++;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                Console.Write((char) (i + 65) + ",\tsayısı: " + countByChar[i]);
                for (int j = 0; j < countByChar[i]; j++)
                {
                    Console.Write(" "+"*");
                }

                Console.WriteLine();
            }
        }
    }
}

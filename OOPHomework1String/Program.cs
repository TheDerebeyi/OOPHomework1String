using System;

//Bir string nesnesi üzerinde aşağıdaki işlemleri yapan programı yazınız?





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
                default:
                    Console.WriteLine("Error.");
                    return;
            }
        }
        //    -	Verilen bir karakter dizininin string nesnesi içerisinde kaç
        // defa bulunduğunu örnek deki gibi yazdırınız?(10)
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
        //    -Verilen bir karakter dizininin substring() metodunu kullanarak string
        // içerisinde kaç defa geçtiğinin örnek deki gibi yazdırınız?(10)

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
        //    -Verilen bir string nesnenin içerisinde Alfabenin karakterlerinin her birinden kaç adet
        // olduğunu bulan ve örnekteki verilen formatta yazdıran kodu yazınız? (30)
        static void Choice3()
        {

        }
    }
}

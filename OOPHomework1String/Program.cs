/****************************************************************************
**	    				    SAKARYA ÜNİVERSİTESİ
**	    			BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**	    			    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**	    			   NESNEYE DAYALI PROGRAMLAMA DERSİ
**		    			    2020-2021 BAHAR DÖNEMİ
**	
**				    ÖDEV NUMARASI..........: Ödev 1 Soru 2
**				    ÖĞRENCİ ADI............: Lütfi Mert Kahraman   
**				    ÖĞRENCİ NUMARASI.......: B201210040
**                  DERSİN ALINDIĞI GRUP...: 1. Öğretim D Grubu
****************************************************************************/

using System;

namespace OOPHomework1String
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;

            do
            {
                Menu();
                Console.Write("\nBaşka bir işlem yapmak ister misiniz?" +
                              "\n1- Evet" +
                              "\n2- Hayır" +
                              "\nSeçiminiz: ");
                choice = Console.ReadLine();
            } while (choice != "2");
        }

        static void Menu()         //Menüyü ekrana çizdirir.
        {
            string cache;

            do
            {
                Console.Clear();
                Console.Write("\tMenü\n" +
                              "1- String bir değişkende, string değeri substring kullanmadan ara.\n" +
                              "2- String bir değişkende, string değeri substring kullanarak ara.\n" +
                              "3- Alfabenin karakterleri bir string içerisinde kaç kere geçiyor bul ve çiz.\n" +
                              "Seçiminiz: ");
                cache = Console.ReadLine();
            } while (cache != "1" && cache != "2" && cache != "3");   //Kullanıcı doğru bir sayı girene kadar döngü devam eder.

            switch (cache)                    //Seçime göre ilgili fonksiyon çağırılıyor.
            {
                case "1":
                    SearchWithoutSubstring();
                    break;
                case "2":
                    SearchWithSubstring();
                    break;
                case "3":
                    CounterPerChar();
                    break;
            }
        }

        static void SearchWithoutSubstring()
        {
            Console.Write("\nAranılacak kelime: ");
            string stringToSearch = Console.ReadLine();
            Console.Write("Karakter Dizini: ");
            string baseString = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < 50; i++)
                Console.Write("-");
            Console.WriteLine();

            int index = 0;

            do
            {
                index = baseString.IndexOf(stringToSearch, index);
                if (index == -1)    //IndexOf fonksiyonu eğer sonuç bulamazsa -1 döndürür. -1 döndürülüp döndürülmediği kontrol ediliyor.
                {
                    if (!found)     //Aranan kelimenin en az bir kere bulunup bulunmadığına bakılıyor.
                    {
                        Console.WriteLine("Kelime bulunamadı!");
                    }

                    return;
                }
                found = true;
                Console.WriteLine("Kelime C# indis: " + index);
                index++;
            } while (true);

        }

        static void SearchWithSubstring()       //Karakter dizini aranan kelimenin uzunluğunda parçalara bölünerek taranır.
        {
            Console.Write("\nAranılacak kelime: ");
            string stringToSearch = Console.ReadLine();
            Console.Write("Karakter Dizini: ");
            string baseString = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < 50; i++)
                Console.Write("-");
            Console.WriteLine();

            for (int i = 0; i < baseString.Length - stringToSearch.Length + 1; i++)   //0'dan itibaren aranan kelimenin uzunluğunda parçalar oluşturuluyor.
            {
                if (baseString.Substring(i, stringToSearch.Length) == stringToSearch) //Eğer elimizdeki parça aranan kelimenin aynısı ise i indisinde cümle bu kelimeyi içeriyor demektir.
                {
                    found = true;
                    Console.WriteLine("Kelime C# indis: " + i);
                }
            }

            if (!found)     //Aranan kelimenin en az bir kere bulunup bulunmadığına bakılıyor.
            {
                Console.WriteLine("Kelime bulunamadı!");
            }
        }

        static void CounterPerChar()
        {
            Console.Write("\nKarakter Dizini: ");
            string baseString = Console.ReadLine();

            Console.WriteLine("\n  Karakter Sayısı   Grafik Gösterimi");

            for (int i = 0; i < 50; i++)
                Console.Write("-");
            Console.WriteLine();

            string upperString = baseString.ToUpper(); //Cümlenin tamamı büyük harflerden oluşan bir kopyası oluşturuluyor.

            int[] countByChar = new int[32];

            for (int i = 0; i < upperString.Length; i++)  //cümlenin tamamı taranıyor
            {
                if (upperString[i] > 64 && upperString[i] < 96)  //ASCII tablosuna göre A'nın kodu 65, Z'nin kodu 95.
                {                                                          //Bu kontrol ile cümlenin i indisindeki karakter bir harf olup olmadığı kontrol ediliyor.
                    countByChar[upperString[i] - 65]++;                    //Eğer bir harf ise A 0'a Z de 25'e denk gelecek şekilde dizinin ilgili elemanı bir arttırılıyor.
                }
                else if (upperString[i] == 286 || upperString[i] == 220 || upperString[i] == 350 ||         //ASCII tablosunda geçerli aralıkta Türkçe karakterler yok
                         upperString[i] == 304 || upperString[i] == 214 || upperString[i] == 199)           //Bu yüzden Türkçe karakter tespiti için ayrı bir kontrol yapılıyor.
                {
                    switch ((int)upperString[i])
                    {
                        case 286:                 //Ğ
                            countByChar[26]++;
                            break;
                        case 220:                 //Ü
                            countByChar[27]++;
                            break;
                        case 350:                 //Ş
                            countByChar[28]++;
                            break;
                        case 304:                 //İ
                            countByChar[29]++;
                            break;
                        case 214:                 //Ö
                            countByChar[30]++;
                            break;
                        case 199:                 //Ç
                            countByChar[31]++;
                            break;
                    }
                }
            }

            for (int i = 0; i < countByChar.Length; i++)                      //Karakterlerin sayısını tutan dizi burada yazdırılıyor.
            {
                if(i < 26)
                    Console.Write("  " + (char)(i + 65) + ",    sayısı: " + countByChar[i] + "  ");
                else
                {
                    switch (i)
                    {
                        case 26:
                            Console.Write("  Ğ,    sayısı: " + countByChar[i] + "  ");
                            break;
                        case 27:
                            Console.Write("  Ü,    sayısı: " + countByChar[i] + "  ");
                            break;
                        case 28:
                            Console.Write("  Ş,    sayısı: " + countByChar[i] + "  ");
                            break;
                        case 29:
                            Console.Write("  İ,    sayısı: " + countByChar[i] + "  ");
                            break;
                        case 30:
                            Console.Write("  Ö,    sayısı: " + countByChar[i] + "  ");
                            break;
                        case 31:
                            Console.Write("  Ç,    sayısı: " + countByChar[i] + "  ");
                            break;
                    }
                }

                    for (int j = 0; j < countByChar[i]; j++)      //Karakter sayısına göre bir yıldız düşecek şekilde görsel gösterim çizdiriliyor.
                {
                    Console.Write(" " + "*");
                }

                Console.WriteLine();
            }
        }
    }
}

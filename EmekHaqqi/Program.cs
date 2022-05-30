using System;
using System.Text;

namespace EmekHaqqi
{
    class Program
    {
        static void Main(string[] args)
        {
         
            //Bu koddan istifade etme sebebim bizim dilimizde ə və ü herflerini tanimadigi ucun internetden baxdim buna

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;


            int xalisEmekhaqqi = 0;
            int usaqPulu = 0;
            string elil = "";
            int umumiEmekhaqqi = 0;
            int usaqSayi = 0;
            int userVergi = 0;
            /*
              Ümumi əmək haqqı (tam ədəd)
               Ailə vəziyyəti (e / E: evli, b / B: subay, d / D: dul)
               Uşaqların sayı (subaydırsa, bu məlumatlar daxil edilməməlidir)
               Əlil olub-olmaması (e / E: bəli, h / N: yox)
             */

            Console.Write("Ümumi əmək haqqı: ");
            umumiEmekhaqqi = Convert.ToInt32(Console.ReadLine());
        aile:
            Console.Write("Ailə vəziyyəti (e / E: evli, b / B: subay, d / D: dul): ");
            string aileVez = Console.ReadLine().ToLower();
            if (aileVez == "e")
            {
                aileVez = "Evli";
                umumiEmekhaqqi += 50;
                Console.Write("Uşaqların sayı: ");
                usaqSayi = Convert.ToInt32(Console.ReadLine());
                usaqPulu = UsaqPulu(usaqSayi, usaqPulu);
                umumiEmekhaqqi += usaqPulu;
                userVergi = usaqVergisi(umumiEmekhaqqi, userVergi);
                Console.Write("Əlilsen (e / E: bəli, h / N: yox): ");
                elil = Console.ReadLine().ToLower();
                if (elil == "e")
                {
                    elil = "Bəli";
                    userVergi /= 2;
                }
                else if (elil == "h")
                {
                    elil = "Yox";
                }
                xalisEmekhaqqi = umumiEmekhaqqi - userVergi;
            }
            else if (aileVez == "b")
            {
                aileVez = "Subay";
                userVergi = usaqVergisi(umumiEmekhaqqi, userVergi);
                Console.Write("Əlilsen (e / E: bəli, h / N: yox): ");
                elil = Console.ReadLine().ToLower();
                if (elil == "e")
                {
                    elil = "Bəli";
                    userVergi /= 2;
                }
                else if (elil == "h")
                {
                    elil = "Yox";
                }
                xalisEmekhaqqi = umumiEmekhaqqi - userVergi;
            }
            else if (aileVez == "d")
            {
                aileVez = "Dul";
                Console.Write("Uşaqların sayı: ");
                usaqSayi = Convert.ToInt32(Console.ReadLine());
                usaqPulu = UsaqPulu(usaqSayi, usaqPulu);
                umumiEmekhaqqi += usaqPulu;
                userVergi = usaqVergisi(umumiEmekhaqqi, userVergi);
                Console.Write("Əlilsiniz (e / E: bəli, h / N: yox): ");
                elil = Console.ReadLine().ToLower();
                if (elil == "e")
                {
                    elil = "Bəli";
                    userVergi /= 2;
                }
                else if (elil == "h")
                {
                    elil = "Xeyr";
                }
                xalisEmekhaqqi = umumiEmekhaqqi - userVergi;
            }
            else
            {
                Console.WriteLine("duzgun daxil etmediz");
                goto aile;
            }





            Console.WriteLine($"Ailə vəziyyəti:{aileVez}\nUsaq pulu: {usaqPulu}\nGəlir vergisinin məbləği:{userVergi}\nÜmumi əmək haqqı:{umumiEmekhaqqi}\nXalis emekhaqqi:{xalisEmekhaqqi}\nUşaqların sayı:{usaqSayi}\nƏlil olub-olmaması:{elil}");






            static int UsaqPulu(int usaqsayi, int usaqPulu)
            {

                int counter = 4;
                if (usaqsayi == 1)
                {
                    usaqPulu += 30;
                }
                else if (usaqsayi == 2)
                {
                    usaqPulu += 55;
                }
                else if (usaqsayi == 3)
                {
                    usaqPulu += 75;
                }
                else
                {
                    usaqPulu += 75;
                    while (counter <= usaqsayi)
                    {
                        usaqPulu += 15;
                        counter++;
                    }
                }
                return usaqPulu;

            }
            static int usaqVergisi(int yeniemekhaqqi, int uservergi)
            {
                if (yeniemekhaqqi <= 1000)
                {
                    uservergi = yeniemekhaqqi * 15 / 100;
                }
                else if (yeniemekhaqqi > 1000 && yeniemekhaqqi <= 2000)
                {
                    uservergi = yeniemekhaqqi * 20 / 100;
                }
                else if (yeniemekhaqqi > 2000 && yeniemekhaqqi <= 3000)
                {
                    uservergi = yeniemekhaqqi * 25 / 100;
                }
                else if (yeniemekhaqqi > 3000)
                {
                    uservergi = yeniemekhaqqi * 30 / 100;
                }
                return uservergi;
            }
        }
    }
}

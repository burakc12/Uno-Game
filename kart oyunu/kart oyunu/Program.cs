using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace kart_oyunu
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kartlar = { "k1", "k2", "k3", "k4", "k5", "m1", "m2", "m3", "m4", "m5", "s1", "s2", "s3", "s4", "s5", "rd", "rd", "rd" };
            string atılansonkart = "yok";
            Random sayı = new Random();
            string[] oyuncu1 = new string[6];
            string[] oyuncu2 = new string[6];
            string[] oyuncu3 = new string[6];
            int i = 0, j = 0, nerderd = 0;
            int a = 0, b = 0, c = 0, kontrol1 = 0, kontrol2 = 0, kontrol3 = 0, pas1 = 0, pas2 = 0, pas3 = 0,pasort=0;
            int tur = 1;
            bool pcoyna = false, oyuncu2oyna = true, oyuncu3oyna = true, rdvarmı = false, rdvarmı2 = false, rdvarmı3 = false, uygunkart = false, baskarenklikart = false, oyunbitirme = false;
            while (a < 6)
            {
                for (i = 0; i < 6; i++)
                {
                    int uretilen = sayı.Next(0, 18);
                    if (kartlar[uretilen] != "yok")
                    {
                        oyuncu1[a] = kartlar[uretilen];
                        kartlar[uretilen] = "yok";
                        a++;
                    }
                    else
                    {
                        i = i - 1;
                    }
                }
            }
            while (b < 6)
            {
                for (i = 0; i < 6; i++)
                {
                    int uret = sayı.Next(0, 18);
                    if (kartlar[uret] != "yok")
                    {
                        oyuncu2[b] = kartlar[uret];
                        kartlar[uret] = "yok";
                        b++;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            while (c < 6)
            {
                for (i = 0; i < 6; i++)
                {
                    int uret = sayı.Next(0, 18);
                    if (kartlar[uret] != "yok")
                    {
                        oyuncu3[c] = kartlar[uret];
                        kartlar[uret] = "yok";
                        c++;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            while (oyunbitirme==false)
            {
                if (pcoyna == false)
                {
                    Console.WriteLine("kartların");
                    foreach (var item in oyuncu1)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine("{0}.tur",tur);
                    Console.WriteLine("lütfen kart atınız pas için pas yazınız ->");
                    string atılan1 = Console.ReadLine();
                    if ((atılan1 == "rd" || atılan1 == "pas") && tur <= 1)
                    {
                        Console.WriteLine("ilk turdan pas veya renk değiştirme kullanılmaz ");
                    }
                    else if (atılan1 == "rd")
                    {
                        for (i = 0; i < 6; i++)
                        {
                            if (oyuncu1[i] == "rd")
                            {
                                nerderd = i;
                                rdvarmı = true;
                                i = 7;
                            }
                        }
                        if (rdvarmı == true)
                        {
                            Console.WriteLine("renk belirleyiniz");
                            string renk = Console.ReadLine();
                            if (renk == "mavi")
                            {
                                atılansonkart = "m" + atılansonkart.Substring(1, 1);
                                Console.WriteLine("Son kart = " + atılansonkart);
                                oyuncu1[nerderd] = "yok";
                                pcoyna = true;
                                kontrol1++;
                            }
                            else if (renk == "sarı")
                            {
                                atılansonkart = "s" + atılansonkart.Substring(1, 1);
                                Console.WriteLine("Son kart = " + atılansonkart);
                                oyuncu1[nerderd] = "yok";
                                pcoyna = true;
                                kontrol1++;
                            }
                            else if (renk == "kırmızı")
                            {
                                atılansonkart = "k" + atılansonkart.Substring(1, 1);
                                Console.WriteLine("Son kart = " + atılansonkart);
                                oyuncu1[nerderd] = "yok";
                                pcoyna = true;
                                kontrol1++;
                            }
                            else
                            {
                                Console.WriteLine("hatalı renk lütfen tekrar dene");
                            }
                        }
                        else
                        {
                            Console.WriteLine("elinizde rd kartı yok lütfen tekrar deneyiniz ");
                        }
                    }
                    else if (atılan1 == "pas"&&tur>=1)
                    {
                        Console.WriteLine("pas dediniz yerdeki kart {0}", atılansonkart);
                        pcoyna = true;
                        pas1++;
                    }
                    else
                    {
                        for (i = 0; i < 6; i++)
                        {
                            if (atılansonkart == "yok" && tur <= 1)
                            {
                                atılansonkart = atılan1;
                                oyuncu1[i] = "yok";
                                pcoyna = true;
                                kontrol1++;
                            }
                            else 
                            if (oyuncu1[i] == atılan1)
                            {
                                if (oyuncu1[i].Substring(0, 1) == atılansonkart.Substring(0, 1) || oyuncu1[i].Substring(1, 1) == atılansonkart.Substring(1, 1)&&tur>1)
                                {
                                    atılansonkart = atılan1;
                                    oyuncu1[i] = "yok";
                                    pcoyna = true;
                                    kontrol1++;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("tekrar deneyin");
                                }
                            }
                        }
                    }
                }
                if (kontrol1 == 6)
                {
                    Console.WriteLine("1.oyuncu oyunu kazandı");
                    pcoyna = false;
                    oyunbitirme = true;
                }
                else if (pcoyna == true)
                {
                    if(oyuncu2oyna == true)
                    {
                        for (j = 0; j < 6; j++)
                        {
                            if (oyuncu2[j].Substring(0, 1) == atılansonkart.Substring(0, 1) || oyuncu2[j].Substring(1, 1) == atılansonkart.Substring(1, 1))
                            {
                                atılansonkart = oyuncu2[j];
                                Console.WriteLine("2.oyuncu yerdeki kartı {0} yaptı", atılansonkart);
                                oyuncu2[j] = "yok";
                                oyuncu2oyna = false;
                                uygunkart=true;
                                kontrol2++;
                                break;
                            }
                        }
                        if (uygunkart == false)
                        {
                            for (j = 0; j < 6; j++)
                            {
                                if (oyuncu2[j] == "rd")
                                {
                                    rdvarmı2 = true;
                                    oyuncu2[j] = "yok";
                                }
                            }
                            if (rdvarmı2 == true)
                            {
                                for (j = 0; j < 6; j++)
                                {
                                    if (oyuncu2[j].Substring(0, 1) == "k"&&tur>=1)
                                    {
                                        atılansonkart = "k" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("2. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı ",atılansonkart);
                                        baskarenklikart = true;
                                        oyuncu2oyna = false;
                                        kontrol2++;
                                        break;
                                    }
                                    if (oyuncu2[j].Substring(0, 1) == "m" && tur >= 1)
                                    {
                                        atılansonkart = "m" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("2. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı ",atılansonkart);
                                        baskarenklikart = true;
                                        oyuncu2oyna = false;
                                        kontrol2++;
                                        break;
                                    }
                                    if (oyuncu2[j].Substring(0, 1) == "s" && tur >= 1)
                                    {
                                        atılansonkart = "s" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("2. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı ",atılansonkart);
                                        baskarenklikart = true;
                                        oyuncu2oyna = false;
                                        kontrol2++;
                                        break;
                                    }
                                }
                                if (baskarenklikart == false)
                                {
                                    Random sayı2 = new Random();
                                    int renk = sayı2.Next(1, 4);
                                    if (renk == 1 && tur >= 1)
                                    {
                                        atılansonkart = "s" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("2. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı " + atılansonkart);
                                        oyuncu2oyna = false;
                                        kontrol2++;
                                    }
                                    else if (renk == 2 && tur >= 1)
                                    {
                                        atılansonkart = "k" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("2. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı " + atılansonkart);
                                        oyuncu2oyna = false;
                                        kontrol2++;
                                    }
                                    else
                                    {
                                        atılansonkart = "m" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("2. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı " + atılansonkart);
                                        oyuncu2oyna = false;
                                        kontrol2++;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("2. oyuncu pas verdi");
                                oyuncu2oyna =false;
                                pas2++;
                            }
                            uygunkart = false;
                        }
                    }
                    if (kontrol2 == 6)
                    {
                        Console.WriteLine("2.oyuncu oyunu kazandı");
                        oyuncu3oyna = false;
                        oyunbitirme = true;
                    }
                    else if (oyuncu3oyna==true)
                    {
                        for (j = 0; j < 6; j++)
                        {
                            if (oyuncu3[j].Substring(0, 1) == atılansonkart.Substring(0, 1) || oyuncu3[j].Substring(1, 1) == atılansonkart.Substring(1, 1) && tur >= 1)
                            {
                                atılansonkart = oyuncu3[j];
                                Console.WriteLine("3.oyuncu yerdeki kartı {0} yaptı", atılansonkart);
                                oyuncu3[j] = "yok";
                                oyuncu2oyna = true;
                                pcoyna = false;
                                tur++;
                                kontrol3++;
                                break;
                            }
                        }
                        if (uygunkart == false)
                        {
                            for (j = 0; j < 6; j++)
                            {
                                if (oyuncu3[j] == "rd")
                                {
                                    rdvarmı3 = true;
                                    oyuncu3[j] = "yok";
                                }
                            }
                            if (rdvarmı3 == true)
                            {
                                for (j = 0; j < 6; j++)
                                {
                                    if (oyuncu3[j].Substring(0, 1) == "k" && tur >= 1)
                                    {
                                        atılansonkart = "k" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("3. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı " ,atılansonkart);
                                         baskarenklikart = true;
                                        pcoyna = false;
                                        oyuncu2oyna = true;
                                        tur++;
                                        kontrol3++;
                                        break;
                                    }
                                    if (oyuncu3[j].Substring(0, 1) == "m" && tur >= 1)
                                    {
                                        atılansonkart = "m" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("3. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı " ,atılansonkart);
                                        baskarenklikart = true;
                                        pcoyna = false;
                                        oyuncu2oyna = true;
                                        tur++;
                                        kontrol3++;
                                        break;
                                    }
                                    if (oyuncu3[j].Substring(0, 1) == "s" && tur >= 1)
                                    {
                                        atılansonkart = "s" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("3. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı " ,atılansonkart);
                                        baskarenklikart = true;
                                        pcoyna = false;
                                        oyuncu2oyna = true;
                                        tur++;
                                        kontrol3++;
                                        break;
                                    }
                                }
                                if (baskarenklikart == false)
                                {
                                    Random sayı3 = new Random();
                                    int renk = sayı3.Next(1, 4);
                                    if (renk == 1 && tur >= 1)
                                    {
                                        atılansonkart = "s" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("3. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı " ,atılansonkart);
                                        pcoyna = false;
                                        oyuncu2oyna = true;
                                        tur++;
                                        kontrol3++;
                                    }
                                    else if (renk == 2 && tur >= 1)
                                    {
                                        atılansonkart = "k" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("3. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı " ,atılansonkart);
                                        pcoyna = false;
                                        oyuncu2oyna = true;
                                        tur++;
                                        kontrol3++;
                                    }
                                    else
                                    {
                                        atılansonkart = "m" + atılansonkart.Substring(1, 1);
                                        Console.WriteLine("3. oyuncu  RD kartını kullanarak yerdeki kartı {0} yaptı " ,atılansonkart);
                                        pcoyna = false;
                                        oyuncu2oyna = true;
                                        tur++;
                                        kontrol3++;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("3. oyuncu pas verdi");
                                pcoyna = false;
                                tur++;
                                pas3++;
                            }
                        }
                        uygunkart = false;
                    }
                    if (kontrol3 == 6)
                    {
                        Console.WriteLine("3.oyuncu oyunu kazandı");
                        oyunbitirme = true;
                    }
                }
                if (pas1 == pas2 && pas1 == pas3 && pas2 == pas3 && pas1 > 1 && pas2 > 1 && pas3 > 1)
                {
                    pasort++;
                    pas1 = 0; pas2 = 0; pas3 = 0;
                }
                else
                {
                    pas1 = 0; pas2 = 0; pas3 = 0;pasort = 0;
                }
                if (pasort == 3)
                {
                    Console.WriteLine("oyun berabere");
                    oyunbitirme = true;
                }
            }
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Hangman
{
    //public static System.Text.Encoding UTF8Encoding { get; set; }
    class Program
    {
        static void Main(string[] args)
        {
            //tarkistetaan onko tiedostoa
            try
            {
                using (StreamReader reader = new StreamReader(@"Words.txt"))
                {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Tiedostoa ei löydy: " + ex);
                return;     //lopetetaan peli jos tiedostoa ei löydy
            }

            //Luetaan tiedoston sanat ja pistetään ne taulukkoon
            string[] lines = File.ReadAllLines(@"Words.txt");

            var random = new Random();              //random sana taulukosta
            int ind = random.Next(lines.Count());
            string sana = lines[ind];
            string sana2 = sana;                  //toinen string valitulle sanalle, jota voi muokata

            List<string> arvatutKirjaimet = new List<string>();  //lista arvatuille kirjaimille, jotka ovat menneet väärin
            List<string> kaikkiArvaukset = new List<string>();  //lista kaikille arvatuille kirjaimille
            List<string> arvatutSanat = new List<string>();     //lista kaikille arvatuille sanoille
            int arvaukset = 5;
            List<string> kirjaimet = new List<string>();        //lista viivoja kirjainten määrän verran
            for (int i = sana.Length; i > 0; i--)
            {
                kirjaimet.Add("_");
            }

            //toistetaan kyselyä niin kauan kuin arvaamattomia kohtia on jäljellä
            do
            {
                Console.WriteLine();
                Console.WriteLine("Hei! Tervetuloa pelaamaan hirsipuuta. Kun haluat arvata koko sanaa, kirjoita '!'.");
                Console.WriteLine();
                Console.WriteLine(string.Format(string.Join(" ", kirjaimet))); //listan kaikki _ yhteen riviin
                Console.WriteLine("Arvatut kirjaimet: {0}", string.Format(string.Join(" ", arvatutKirjaimet)));
                Console.WriteLine("Arvatut sanat: {0}", string.Format(string.Join(" ", arvatutSanat)));
                Console.WriteLine("Arvauksia jäljellä: {0}", arvaukset);
                switch (arvaukset)
                {
                    case 5:
                        Pictures.print0();
                        break;
                    case 4:
                        Pictures.print1();
                        break;
                    case 3:
                        Pictures.print2();
                        break;
                    case 2:
                        Pictures.print3();
                        break;
                    case 1:
                        Pictures.print4();
                        break;
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
                Console.WriteLine("Arvaus: ");
                string arvaus = Console.ReadLine();         //Käyttäjä syöttää arvauksen
                Console.WriteLine();

                if (arvaus.Length > 1)                      //estää useamman kuin yhden merkin antamisen 
                {
                    Console.Clear();                        //tyhjennä konsolin näyttö
                    Console.WriteLine("Anna vain yksi kirjain kerrallaan");
                }

                else if (kaikkiArvaukset.Contains(arvaus))  //estää kirjaimen arvaamisen enemmän kuin kerran
                {
                    Console.Clear();
                    Console.WriteLine("Kirjainta on arvattu jo");
                }

                else
                {
                    if (sana2.Contains(arvaus))                  //kirjain löytyy
                    {
                        while (sana2.Contains(arvaus))
                        {
                            int index = sana2.IndexOf(arvaus);       //vaihdetaan _ tilalle kirjain selvittämällä kirjaimen paikka
                            sana2 = sana2.Remove(index, 1);          //poistetaan kirjain 
                            sana2 = sana2.Insert(index, ";");        //laitetaan ';' tilalle, jotta kaikki kirjaimet tarkistetaan jos niitä on monta
                            kirjaimet.RemoveAt(index);              //poistetaan _
                            kirjaimet.Insert(index, arvaus);        //laitetaan kirjain viivan paikalle
                            Console.Clear();                        
                        }
                    }

                    else if (arvaus == "!")                     //Arvataan koko sanaa
                    {
                        Console.WriteLine("Arvaan, että sana on: ");
                        string a = Console.ReadLine();
                        if (a == sana)                          //sanan arvaus menee oikein
                        {
                            Pictures.printWin();
                            return;
                        }
                        else                                    //sanan arvaus menee väärin
                        {
                            Console.Clear();                        
                            Console.WriteLine("Väärin");
                            arvaukset--;
                            arvatutSanat.Add(a);
                            if (arvaukset == 0)                     //arvauksien määrä loppuu
                            {
                                Pictures.printLose();
                                Console.WriteLine();
                                Console.WriteLine(sana);
                                return;                             //peli loppuu
                            }
                        }
                    }

                    else                                        //kirjainta ei löydy
                    {
                        Console.Clear();
                        Console.WriteLine("Ei ole");
                        arvatutKirjaimet.Add(arvaus);
                        arvaukset--;
                        if (arvaukset == 0)                     //arvauksien määrä loppuu
                        {
                            Pictures.printLose();
                            Console.WriteLine();
                            Console.WriteLine(sana);
                            return;                             //peli loppuu
                        }
                    }
                }
                kaikkiArvaukset.Add(arvaus);                //lisää arvauksen listaan
                kaikkiArvaukset.Remove("!");                //poistaa "!", että voi arvata useamman kerran
            }
            while (kirjaimet.Contains("_"));                //silmukka toistuu niin pitkään kunnes kaikki on arvattu
            Console.WriteLine("{0}", sana);
            Pictures.printWin();                            //Käyttäjä voittaa arvaamalla kirjaimet yksitellen
            return;                                         //peli lopppuu
        }
    }
}
using System;

namespace Hangman
{
    class Pictures
    {
        public static void printWin()
        {
            Console.WriteLine("Voitto!:)");             //pelaaja voittaa
            Console.WriteLine("    ___");
            Console.WriteLine("   |   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |           O/");
            Console.WriteLine(" __|__        /|/");
            Console.WriteLine("(     )       /");
        }
        public static void printLose()
        {
            Console.WriteLine("Häviö:(");               //pelaaja häviää
            Console.WriteLine("    ___");
            Console.WriteLine("   |   |");
            Console.WriteLine("   |   O/");
            Console.WriteLine("   |  /|/");
            Console.WriteLine("   |  / ");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("(     )");
        }

        public static void print0()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        public static void print1()
        {
            Console.WriteLine("");               
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" __ __ ");
            Console.WriteLine("(     )");
        }

        public static void print2()
        {
            Console.WriteLine("");              
            Console.WriteLine("    ");
            Console.WriteLine("   |   ");
            Console.WriteLine("   |   ");
            Console.WriteLine("   |  ");
            Console.WriteLine("   |   ");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("(     )");
        }

        public static void print3()
        {
            Console.WriteLine("");               
            Console.WriteLine("    ___");
            Console.WriteLine("   |   ");
            Console.WriteLine("   |  ");
            Console.WriteLine("   |  ");
            Console.WriteLine("   |  ");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("(     )");
        }

        public static void print4()
        {
            Console.WriteLine("");               
            Console.WriteLine("    ___");
            Console.WriteLine("   |   |");
            Console.WriteLine("   |  ");
            Console.WriteLine("   |  ");
            Console.WriteLine("   |  ");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("(     )");
        }
    }
}

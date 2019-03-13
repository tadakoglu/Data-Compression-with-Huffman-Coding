using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename;
            Console.Write("Açılacak dosya ismini girin(Örn:pau.txt): ");
            filename = Console.ReadLine();//Get filename from user prompt
            try
            {
                FileStream stream = new FileStream(filename, FileMode.Open);//Open file (filename) in read mode
                for (int i = 0; i < stream.Length; i++)//Main loop to read bytes from file
                {
                    int read = stream.ReadByte();//All values are in range of [0,255]
                    Console.Write((char)read);//Print the value read from file by casting to char
                }
            }
            catch(Exception e)//Exceptional situation
            {
                Console.WriteLine("Hata:"+e.Message);//Print error
            }
            Console.ReadKey();//Wait for user input
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename;
            Console.WriteLine("DAVID A. HUFFMAN CODING DATA COMPRESSION ALGORITHM BY 11253001-TAYFUN ADAKOGLU, PAMUKKALE UNIVERSITY");
            Console.Write("ENTER THE FILE LOCATION, PAU.TXT READY FOR YOU. FOR EXAMPLE WRITE PAU.TXT\nloc//:");
            filename = Console.ReadLine(); //Get filename from user prompt
            string input = "";
            try
            {
                        FileStream stream = new FileStream(filename, FileMode.Open);//Open file (filename) in read mode       
                        for (int i = 0; i < stream.Length; i++)//Main loop to read bytes from file
                        {
                          int read = stream.ReadByte();//All values are in range of [0,255]
                          input += (char)read;
                        }                           
           
                        HuffmanTree huffmanTree = new HuffmanTree();
                        // Build the Huffman tree
                        huffmanTree.Build(input);
                        BitArray encoded = null;                      
                        Console.WriteLine("_______________________________________________________________________");
                        Console.WriteLine("ASCII NO\tKEY\t\tFREQUENCY\tHUFFMAN CODE");                  
                        // PRINT 
                        foreach (KeyValuePair<char, int> symbol in huffmanTree.Frequencies)
                        {
                            if ((int)symbol.Key == 10) // NEW LINE CHARACTER
                            Console.Write((int)symbol.Key + "\t\t" + "(LF)" + "\t\t" + symbol.Value + "\t\t");
                            else if ((int)symbol.Key == 32) // SPACE
                                Console.Write((int)symbol.Key + "\t\t" + "(SPACE)" + "\t\t" + symbol.Value + "\t\t");
                            else if ((int)symbol.Key == 13) // CARRIAGE RETURN
                                Console.Write((int)symbol.Key + "\t\t" + "(CR)" + "\t\t" + symbol.Value + "\t\t");      
                            else
                            Console.Write((int)symbol.Key + "\t\t" + symbol.Key + "\t\t" + symbol.Value + "\t\t");

                            // ENCODING - DAVID HUFFMAN CODE
                            encoded = huffmanTree.Encode(symbol.Key);
                            foreach (bool bit in encoded)
                            {
                                Console.Write((bit ? 1 : 0) + "");
                            }
                            Console.WriteLine();
                            
                        }

                        Console.WriteLine("_______________________________________________________________________");
                        Console.WriteLine("Some special characters may be given by name not to make the list into disorder!");
                        Console.WriteLine("'CR' : CARRIAGE RETURN , 'LF' : LINE FEED AND SPACE MEANS ' '");
                       
                       

            }
            catch (Exception e) //EXCEPTION
            {
                         Console.WriteLine("Hata:" + e.Message + "\n");//Print error
                         Main(args); // For starting again
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(args[0]);
            char[] nonterminals = reader.ReadLine().ToCharArray();
            char[] terminals = reader.ReadLine().ToCharArray();
            int grammmar_length = Convert.ToInt32(reader.ReadLine());
            char[,] grammar = new char[nonterminals.Length, terminals.Length+2];
            string[] mapped_terminals = new string[grammmar_length+1];
            

            // create 2d array for parse table
            // populate columns with the nonterminals
            for (int i = 0; i < nonterminals.Length; i++)
            {
                grammar[i,0] = nonterminals[i];
            }

            

            //  parse and map terminals to digits
            for (int i = 1; i < grammmar_length+1; i++)
            {
                string[] testchar = (reader.ReadLine().Split());
                mapped_terminals[i] = testchar[1];
                Console.WriteLine(mapped_terminals[i]);

            }

            // parse table values in
            for (int i = 0; i < nonterminals.Length; i++)
            {
                string[] table_ints = reader.ReadLine().Split();

                for (int j = 0; j < terminals.Length+1; j++)
                {
                    
                    int int_conv = Convert.ToInt32(table_ints[j]);
                    grammar[i,j+1] = Convert.ToChar(int_conv);
                }
                
                    

                    
                
            }


            Console.ReadLine();
            // read in remaining lines using the parsed int

            //            foreach (var VARIABLE in nonterminals)
            //            {
            //                Console.WriteLine(VARIABLE);
            //                Console.WriteLine(nonterminals.Length);
            //                Console.ReadLine();
            //            }


        }
    }
}

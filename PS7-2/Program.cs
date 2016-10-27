﻿using System;
using System.Collections;
using System.IO;

namespace PS7_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var langText = new StreamReader(args[0]);
            var inpText = new StreamReader(args[1]);
            var nonterminals = langText.ReadLine().ToCharArray();
            var terminals = langText.ReadLine().ToCharArray();
            var grammmar_length = Convert.ToInt32(langText.ReadLine());
            var grammar = new char[nonterminals.Length, terminals.Length + 2];
            var mapped_terminals = new string[grammmar_length + 1];

            

            // create 2d array for parse table
            // populate columns with the nonterminals
            for (var i = 0; i < nonterminals.Length; i++)
            {
                grammar[i, 0] = nonterminals[i];
            }


            //  parse and map terminals to digits
            for (var i = 1; i < grammmar_length + 1; i++)
            {
                var testchar = langText.ReadLine().Split();
                mapped_terminals[i] = testchar[1];
                //Console.WriteLine(mapped_terminals[i]);
            }

            // parse in table values 
            for (var i = 0; i < nonterminals.Length; i++)
            {
                var table_ints = langText.ReadLine().Split();

                for (var j = 0; j < terminals.Length + 1; j++)
                {
                    var int_conv = Convert.ToInt32(table_ints[j]);
                    grammar[i, j + 1] = Convert.ToChar(int_conv);
                }
            }

            while (!inpText.EndOfStream)
            {
                var charStack = new Stack();
                var stringStack = new Stack();

                string inpString = inpText.ReadLine();
                char[] charstring = inpString.ToCharArray();
                foreach (var letter in charstring)
                {
                    stringStack.Push(letter);
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

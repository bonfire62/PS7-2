using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PS7_2
{
    internal class Parser_u0489803
    {
        private static void Main(string[] args)
        {
            var langText = new StreamReader(args[0]);
            var inpText = new StreamReader(args[1]);
            var nonterminals = langText.ReadLine().ToCharArray();
            var terminals = langText.ReadLine().ToCharArray();
            var grammmar_length = Convert.ToInt32(langText.ReadLine());
            var grammar = new string[nonterminals.Length, terminals.Length + 2];
            var mapped_terminals = new string[grammmar_length + 1];


            // create 2d array for parse table
            // populate columns with the nonterminals
            for (var i = 0; i < nonterminals.Length; i++)
            {
                grammar[i, 0] = nonterminals[i].ToString();
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
                    grammar[i, j + 1] = mapped_terminals[int_conv];
                }
            }

            while (inpText.Peek() > 0)
            {
                var charStack = new Stack<char>();
                var stringStack = new Stack<char>();


                var inpString = inpText.ReadLine();
                var charstring = inpString.ToCharArray();
                for (var i = charstring.Length - 1; i >= 0; i--)
                {
                    stringStack.Push(charstring[i]);
                }
                //todo populate stack
                charStack.Push(Convert.ToChar(grammar[0, 0]));

                while (charStack.Count > 0)
                {
                    // terminals check

                    // if its a nonterminal on the stack
                    if (nonterminals.Contains(charStack.Peek()))
                    {
                        var stackNonTerminal = charStack.Peek();
                        charStack.Pop();
                        var column = 0;
                        var row = 0;
                        // find row value for Nonterminal in table
                        for (var i = 0; i < nonterminals.Length; i++)
                        {
                            // checks grammar table for correct X
                            if (Convert.ToChar(grammar[i, 0]) == stackNonTerminal)
                            {
                                // checks for the right column in grammar from table
                                row = i;
                                break;
                            }
                        }
                        //find column value (Terminal in table
                        if (stringStack.Count > 0)
                        {
                            for (var i = 0; i < terminals.Length; i++)
                            {
                                if (stringStack.Peek() == terminals[i])
                                {
                                    column = i + 1;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            column = terminals.Length + 1;
                        }

                        // loop to push values from grammar onto stack that correspond to the nonterminal
                        if (grammar[row, column] != null)
                        {
                            for (var i = grammar[row, column].ToCharArray().Length - 1; i >= 0; i--)
                            {
                                charStack.Push(grammar[row, column][i]);
                                if (charStack.Peek() == '-')
                                {
                                    charStack.Pop();
                                }
                            }
                        }
                    }
                    // else if its a terminal on the stack
                    else if (terminals.Contains(charStack.Peek()))
                    {
                        if (stringStack.Count > 0 && charStack.Peek() > 0)

                        {
                            if (stringStack.Peek() == charStack.Peek())
                            {
                                stringStack.Pop();
                                charStack.Pop();
                            }
                            else
                            {
                                Console.WriteLine("no");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("no");
                            break;
                        }
                    }

                    if (stringStack.Count == 0 && charStack.Count == 0)
                    {
                        Console.WriteLine("yes");
                        break;
                    }
                    if (charStack.Count == 0 && stringStack.Count > 0)
                    {
                        Console.WriteLine("no");

                        break;
                    }
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
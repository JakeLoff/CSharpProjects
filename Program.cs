using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a linked list of type int
            var list = new LinkedList<int>();
            try
            {
                //Read the first line of the text file with the numbers and split by ','
                string numbers;
                StreamReader inputFile = new StreamReader("numbers.txt");
                numbers = inputFile.ReadLine();
                string[] split = numbers.Split(',');
                //Add the numbers to the list
                for (int i = 0; i <= 9; i++)
                {
                    if (split[i] == " ")
                    {
                        break;
                    }
                    list.AddLast(Convert.ToInt32(split[i]));
                }
                //Close the input
                inputFile.Close();
                //Create a sorted version of the list and display it
                var listOrdered = list.OrderBy(i => i);
                foreach (var item in listOrdered)
                {
                    Console.Write(item + "  ");
                    Console.WriteLine();
                }
                running(listOrdered);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file.");
                Console.ReadKey();
            }
            
        }

        //Continous running method after creating the sorted list
        private static void running(IOrderedEnumerable<int> listOrdered)
        {
            while (true)
            {
                //Ask for an input number to search
                Console.WriteLine("Search for a string: ");
                String input = Console.ReadLine();
                //If no input, end the application
                if (input == "")
                {
                    break;
                }
                //Otherwise search the list for that number
                else
                {
                    int check = Convert.ToInt32(input);
                    int position = 0;
                    Boolean found = false;
                    //If found print out the position
                    foreach (var item in listOrdered)
                    {
                        if (item == check)
                        {
                            found = true;
                            Console.WriteLine("Match found in position: " + position);
                            break;
                        }
                        else
                        {
                            position++;
                        }
                    }
                    //If the number isn't found after searching the list print that no match was found
                    if (found == false)
                    {
                        Console.WriteLine("No match found");
                    }
                }
            }
        }
    }
}


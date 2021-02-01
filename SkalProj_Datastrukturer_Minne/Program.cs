using System;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    /// <summary>
    /// TOD SVARA PÅ FRÅGORNA
    /// 
    /// 1. Hur fungerar stacken och heapen ? Förklara gärna med exempel eller skiss på dess grundläggande funktion
    /// 2. Vad är Value Types repsektive Reference Types och vad skiljer dem åt?
    /// 3. Följande metoder(se bild nedan ) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?
    /// TODO SE BILD, sid 3, I LABB PDF
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// 
        /// Svar på frågor
        /// När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
        ///     Listans kapacitet ökas när man når nuvarande kapacitet
        ///     
        /// Med hur mycket ökar kapaciteten? 
        /// Storleken på listan dubblas
        /// 
        /// Varför ökar inte listans kapacitet i samma takt som element läggs till? 
        ///     Det skulle leda till att listan måste allokeras om för varje element som läggs till. Ger dålig prestanda
        ///     
        /// Minskar kapaciteten när element tas bort ur listan? 
        ///     Nej
        ///     
        /// När är det då fördelaktigt att använda en egendefinierad array istället för en lista? 
        ///     Om man vet hur många elemet som skall lagras i arrayen och att man inte ändrar antalet element i arrayen
        ///     
        /// </summary>
        static void ExamineList()
        {
            Console.WriteLine("ExamineList");

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            // Lista med inmatningar från användaren
            List<string> lsInput = new List<string>();
            bool bRun = true;
            string strInput = String.Empty;
            do
            {   
                // Rensa
                strInput = String.Empty;                
                Console.Clear();

                // Visa menyn
                Console.WriteLine(MenuFactory.GetMenu(MenuType.EXAMINELIST));

                strInput = Console.ReadLine();

                if(!String.IsNullOrWhiteSpace(strInput))
                {
                    strInput = strInput.Trim();

                    if(strInput.StartsWith('+') && strInput.Length > 1)
                    {// Användaren vill lägga till en text

                        Console.WriteLine(System.Environment.NewLine);

                        // Hämta inmatningen från tecken 1
                        strInput = strInput.Substring(1);
                        strInput = strInput?.Trim();
                        if (strInput?.Length > 0)
                        {// Lägg till texten till listan
                            lsInput.Add(strInput);
                        }

                        PrintToConsole(lsInput);
                        Console.ReadLine();
                    }
                    else if(strInput.StartsWith('-') && strInput.Length > 1)
                    {// Användaren vill radera en text

                        Console.WriteLine(System.Environment.NewLine);

                        // Hämta inmatningen från tecken 1
                        strInput = strInput.Substring(1);
                        strInput = strInput?.Trim();
                        if (strInput?.Length > 0)
                        {// Radera texten från listan
                            lsInput.Remove(strInput);
                        }

                        PrintToConsole(lsInput);
                        Console.ReadLine();
                    }
                    else if(strInput.StartsWith('0'))
                    {// Användaren vill avsluta och återgå till huvudmenyn

                        Console.ReadLine();
                        bRun = false;
                    }
                    else if (strInput.StartsWith('1'))
                    {// Användaren vill att innehållet i listan visas

                        PrintToConsole(lsInput);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Använd + för att lägga till text, - för att radera text och 0 för att återgå till huvudmenyn");
                        Console.ReadLine();
                    }
                }

            }while (bRun);
        }


        /// <summary>
        /// Metoden skriver ut information om listan och innehållet i listan till console
        /// </summary>
        /// <param name="lsList"></param>
        private static void PrintToConsole(List<string> lsList)
        {
            Console.WriteLine($"PrintToConsole. {lsList.Count} ({lsList.Capacity})." + System.Environment.NewLine);

            foreach (string str in lsList)
            {
                Console.WriteLine(str);
            }
        }


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Console.WriteLine("ExamineQueue");

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Console.WriteLine("ExamineStack");

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            Console.WriteLine("CheckParanthesis");

            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}


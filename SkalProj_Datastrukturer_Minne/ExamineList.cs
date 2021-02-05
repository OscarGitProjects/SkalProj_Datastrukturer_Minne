using System;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    public class ExamineList
    {

        #region ExamineList

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
        public void RunExamineList()
        {
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

                if (!String.IsNullOrWhiteSpace(strInput))
                {
                    strInput = strInput.Trim();

                    if (strInput.StartsWith('+') && strInput.Length > 1)
                    {// Användaren vill lägga till en text

                        Console.WriteLine(System.Environment.NewLine);

                        // Hämta inmatningen från tecken 1
                        strInput = strInput.Substring(1);
                        strInput = strInput?.Trim();
                        if (strInput?.Length > 0)
                        {// Lägg till texten till listan
                            lsInput.Add(strInput);
                        }

                        PrintListToConsole(lsInput);

                        Console.WriteLine("Enter för att gå vidare");
                        Console.ReadLine();
                    }
                    else if (strInput.StartsWith('-') && strInput.Length > 1)
                    {// Användaren vill radera en text

                        Console.WriteLine(System.Environment.NewLine);

                        // Hämta inmatningen från tecken 1
                        strInput = strInput.Substring(1);
                        strInput = strInput?.Trim();
                        if (strInput?.Length > 0)
                        {// Radera texten från listan
                            lsInput.Remove(strInput);
                        }

                        PrintListToConsole(lsInput);

                        Console.WriteLine("Enter för att gå vidare");
                        Console.ReadLine();
                    }
                    else if (strInput.StartsWith('0'))
                    {// Användaren vill avsluta och återgå till huvudmenyn

                        Console.ReadLine();
                        bRun = false;
                    }
                    else if (strInput.StartsWith('1'))
                    {// Användaren vill att innehållet i listan visas

                        PrintListToConsole(lsInput);

                        Console.WriteLine("Enter för att gå vidare");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Använd + för att lägga till text, - för att radera text, 0 för att återgå till huvudmenyn och 1 för att visa listan");
                        Console.ReadLine();
                    }
                }

            } while (bRun);
        }


        /// <summary>
        /// Metoden skriver ut information om listan och innehållet i listan till console
        /// </summary>
        /// <param name="lsList"></param>
        private void PrintListToConsole(List<string> lsList)
        {
            Console.WriteLine($"PrintToConsole. {lsList.Count} ({lsList.Capacity})." + System.Environment.NewLine);

            foreach (string str in lsList)
            {
                Console.WriteLine(str);
            }
        }

    #endregion  // End of region ExamineList

    }
}

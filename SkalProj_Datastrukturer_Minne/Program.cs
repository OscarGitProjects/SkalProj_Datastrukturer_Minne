using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    /// <summary>
    /// 
    /// 1. Hur fungerar stacken och heapen ? Förklara gärna med exempel eller skiss på dess grundläggande funktion
    ///     Stacken är tillfällig minnesarea där ett program vid bland annat anrop till metoder allokerar minne för variabler som är deklarerade i metoden.
    ///     Statisk minnesallokering. När metoden avslutas kommer variablerna som är allokerade på stacken automatiskt att raderas. 
    ///        
    ///     Om någon av variablerna är en reference till ett objekt kommer det att sparas på heapen. dvs dynamisk allokerat med new.
    ///     Referenser som finns på heapen raderas av GC, Garbage collectorn
    /// 
    ///     När metoden avslutas raderas variablerna från stacken och c# skräphanterare kommer så småningom radera objekten som finns på heapen
    ///     Dynamisk minnesallokering. 
    ///     
    ///     Stacken är en så kallad LIFO minnes kontruktion där det som senast adderades till stacken är det som raderas först.
    ///     Heapen är en minnes konstruktion där man med adressen till minnet kan hämta vad man vill. Heapen har koll på om något objekt refererar till minnesadressen.
    ///     Om det inte finns någon referens till det som finns på en minnesadress kommer GC, Garbage collectorn att radera det som finns.
    ///     
    ///     
    /// 2. Vad är Value Types repsektive Reference Types och vad skiljer dem åt?
    ///     Där en Value type sparas i minnet där sparas också värdet. Sparas i den del av minnet som kallas stacken
    ///     Där en Reference Type sparas i minnet är det adressen till en annan del i minnet där värdet sparas. Sparas i den del av minnet som kallas heapen
    ///     
    /// 
    /// 3. Följande metoder(se bild nedan ) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
    ///     int x = new int(), skapar värdetypen int. Om man sätter y = x; innebär det att värdet från x sparas i minet där y finns.
    ///     
    ///     MyInt x = new MyInt() skapar en referens till objektet MyInt. Referens är en adress i minnet där värdet sparas.
    ///     När man sätter y = x; innebär det att y referensen kommer att peka på samma adress som x. 
    ///     Om jag ändrar värdet på y kommer jag att ändra värdet på den adress i minnet som y och x pekar på
    /// 
    /// 
    /// 
    /// Svar på frågor om List
    ///     När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
    ///         Listans kapacitet ökas när man når nuvarande kapacitet
    ///     
    ///     Med hur mycket ökar kapaciteten? 
    ///         Storleken på listan dubblas
    /// 
    ///     Varför ökar inte listans kapacitet i samma takt som element läggs till? 
    ///         Det skulle leda till att listan måste allokeras om för varje element som läggs till. Ger dålig prestanda
    ///     
    ///     Minskar kapaciteten när element tas bort ur listan? 
    ///         Nej
    ///     
    ///     När är det då fördelaktigt att använda en egendefinierad array istället för en lista? 
    ///         Om man vet hur många elemet som skall lagras i arrayen och att man inte ändrar antalet element i arrayen
    /// 
    /// 
    /// 
    /// Svar på frågor om Stack
    ///     Simulera ännu en gång ICA-kön på papper. Denna gång med en stack . Varför är det inte så smart att använda en stack i det här fallet?
    ///         En stack är en så kallad LIFO samling av data. Det innebär att det som adderades sist är det som hämtas först. 
    ///         Vilket är tvärt om en kö som är en så kallad FIFO samling av data. Där den som adderades först hämtas först. Det är ju så här en vanlig kö i ICA butiken fungerar
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

                        PrintListToConsole(lsInput);
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

                        PrintListToConsole(lsInput);
                        Console.ReadLine();
                    }
                    else if(strInput.StartsWith('0'))
                    {// Användaren vill avsluta och återgå till huvudmenyn

                        Console.ReadLine();
                        bRun = false;
                    }
                    else if (strInput.StartsWith('1'))
                    {// Användaren vill att innehållet i listan visas

                        PrintListToConsole(lsInput);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Använd + för att lägga till text, - för att radera text, 0 för att återgå till huvudmenyn och 1 för att visa listan");
                        Console.ReadLine();
                    }
                }

            }while (bRun);
        }


        /// <summary>
        /// Metoden skriver ut information om listan och innehållet i listan till console
        /// </summary>
        /// <param name="lsList"></param>
        private static void PrintListToConsole(List<string> lsList)
        {
            Console.WriteLine($"PrintToConsole. {lsList.Count} ({lsList.Capacity})." + System.Environment.NewLine);

            foreach (string str in lsList)
            {
                Console.WriteLine(str);
            }
        }

        #endregion  // End of region ExamineList


        #region ExamineQueue

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

            // Queue med inmatningar från användaren
            Queue<string> queue = new Queue<string>();
            bool bRun = true;
            string strInput = String.Empty;

            do
            {
                // Rensa
                strInput = String.Empty;
                Console.Clear();

                // Visa menyn
                Console.WriteLine(MenuFactory.GetMenu(MenuType.EXAMINEQUEUE));

                strInput = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(strInput))
                {
                    strInput = strInput.Trim();

                    if (strInput.StartsWith('+') && strInput.Length > 1)
                    {// Användaren vill lägga till en person i kön

                        Console.WriteLine(System.Environment.NewLine);

                        // Hämta inmatningen från tecken 1
                        strInput = strInput.Substring(1);
                        strInput = strInput?.Trim();
                        if (strInput?.Length > 0)
                        {// Lägg till namnet på personen till kön
                            queue.Enqueue(strInput);
                        }

                        PrintQueueToConsole(queue);
                        Console.ReadLine();
                    }
                    else if (strInput.StartsWith('0'))
                    {// Användaren vill avsluta och återgå till huvudmenyn

                        //Console.ReadLine();
                        bRun = false;
                    }
                    else if (strInput.StartsWith('1'))
                    {// Användaren vill att innehållet i kön visas

                        PrintQueueToConsole(queue);
                        Console.ReadLine();
                    }
                    else if (strInput.StartsWith('2'))
                    {// Användaren vill att en person lämnar kön

                        queue.Dequeue();
                        PrintQueueToConsole(queue);
                        Console.ReadLine();
                    }
                    else if (strInput.StartsWith('3'))
                    {// Simulera en kö

                        SimuleraEnKo();
                    }
                    else
                    {
                        Console.WriteLine("Använd + för att lägga till person, 0 för att återgå till huvudmenyn, 1 för att visa kön, 2 för att en person skall lämna kön och 3 för att simulera en kö");
                        Console.ReadLine();
                    }
                }

            } while (bRun);
        }


        /// <summary>
        /// Metoden simulerar att folk ställer sig i en kö och lämnar kön
        /// </summary>
        private static void SimuleraEnKo()
        {
            int iRandomValue = 0;
            string strName = String.Empty;
            string strRemovedName = String.Empty;
            Random random = new Random();
            Queue<string> queue = new Queue<string>();

            Console.WriteLine("Nu simuleras en kö. Vänta tills det är klart");
            Console.WriteLine("ICA öppnar och kön till kassan är tom");

            for (int i = 0; i < 10; i++)
            {
                iRandomValue = random.Next(0, 3);

                switch(iRandomValue)
                {
                    case 0: // Inget händer med kön
                        break;
                    case 1: // En person ställer sig i kö
                        strName = Helper.GetRandomName();
                        Console.WriteLine($"{strName} ställer sig i kö");
                        queue.Enqueue(strName);
                        PrintQueueToConsole(queue);
                        Console.WriteLine(System.Environment.NewLine);
                        break;
                    case 2: // En person lämnar kön
                        try
                        {
                            strRemovedName = queue.Dequeue();
                            Console.WriteLine($"{strRemovedName} lämnar kön");
                            PrintQueueToConsole(queue);
                            Console.WriteLine(System.Environment.NewLine);
                        }
                        catch(Exception)
                        {// Undantag kan kastas om queue är tom
                            //Console.WriteLine("Exception");
                        }

                        break;
                    default:
                        break;

                }                         
            }            

            //Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("Avsluta simuleringen med att trycka på return");
            Console.ReadLine();
        }


        /// <summary>
        /// Metoden skriver ut information om kön till console
        /// </summary>
        /// <param name="queeue">Kö med personer som vi skall skriva ut information om</param>
        private static void PrintQueueToConsole(Queue<string> queeue)
        {
            StringBuilder strBuilder = new StringBuilder($"Följande personer står i kö ({queeue.Count}). ");

            int iCount = 0;
            foreach (string str in queeue)
            {
                if(iCount > 0)
                    strBuilder.Append(", ");

                strBuilder.Append(str);
                iCount++;
            }

            Console.WriteLine(strBuilder.ToString());
        }

        #endregion  // End of region ExamineQueue


        #region ExamineStack

        /// <summary>
        /// Examines the datastructure Stack
        /// 
        /// Simulera ännu en gång ICA-kön på papper. Denna gång med en stack . Varför är det inte så smart att använda en stack i det här fallet?
        ///     En stack är en så kallad LIFO samling av data. Det innebär att det som adderades sist är det som hämtas först. 
        ///     Vilket är tvärt imot en kö som är en så kalald FIFO samling av data. Där den som adderades först hämtas först
        ///
        /// </summary>
        static void ExamineStack()
        {
            Console.WriteLine("ExamineStack");

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            // Stack med inmatning från användaren
            Stack<string> stacken = new Stack<string>();
            bool bRun = true;
            string strInput = String.Empty;

            do
            {
                // Rensa
                strInput = String.Empty;
                Console.Clear();

                // Visa menyn
                Console.WriteLine(MenuFactory.GetMenu(MenuType.EXAMINESTACK));

                strInput = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(strInput))
                {
                    strInput = strInput.Trim();

                    if (strInput.StartsWith('0'))
                    {// Användaren vill avsluta och återgå till huvudmenyn

                        //Console.ReadLine();
                        bRun = false;
                    }
                    else
                    {
                        // Spara varje tecken från input i en stack
                        foreach(char ch in strInput)
                        {
                            stacken.Push(ch.ToString());
                        }

                        PrintStackToConsole(stacken);
                        Console.ReadLine();
                    }
                }

            } while (bRun);
        }


        /// <summary>
        /// Metoden skriver ut inofrmation om stacken till consolen
        /// </summary>
        /// <param name="stacken">Stack med information som  skall skrivas ut</param>
        private static void PrintStackToConsole(Stack<string> stacken)
        {
            StringBuilder strBuilder = new StringBuilder($"Följande tecken finns i stacken ({stacken.Count}). ");

            int iCount = 0;

            foreach(string str in stacken)
            {
                if (iCount > 0)
                    strBuilder.Append(", ");

                strBuilder.Append(str);
                iCount++;
            }

            Console.WriteLine(strBuilder.ToString());
        }

        #endregion  // End of region ExamineStack


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


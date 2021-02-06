using System;

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
    ///     Simulera ännu en gång ICA-kö på papper. Denna gång med en stack . Varför är det inte så smart att använda en stack i det här fallet?
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
                Console.Clear();

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
        /// Övning 1: ExamineList()
        /// 
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

            ExamineList examineList = new ExamineList();
            examineList.RunExamineList();
        }

        #endregion  // End of region ExamineList


        #region ExamineQueue

        /// <summary>
        /// Övning 2: ExamineQueue()
        /// 
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

            ExamineQueue examinQueue = new ExamineQueue();
            examinQueue.RunExamineQueue();
        }

        #endregion  // End of region ExamineQueue


        #region ExamineStack

        /// <summary>
        /// Övning 3: ExamineStack()
        /// 
        /// Examines the datastructure Stack
        /// 
        /// Simulera ännu en gång ICA-kö på papper. Denna gång med en stack . Varför är det inte så smart att använda en stack i det här fallet?
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

            ExamineStack examineStack = new ExamineStack();
            examineStack.RunExamineStack();
        }

        #endregion  // End of region ExamineStack


        #region CheckParanthesis

        /// <summary>
        /// Övning 4: CheckParanthesis()
        /// 
        /// </summary>
        static void CheckParanthesis()
        {
            Console.WriteLine("CheckParanthesis");

            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            CheckParanthesis checkParanthesis = new CheckParanthesis();
            checkParanthesis.RunCheckParanthesis();
        }

        #endregion  // End of region CheckParanthesis
    }
}


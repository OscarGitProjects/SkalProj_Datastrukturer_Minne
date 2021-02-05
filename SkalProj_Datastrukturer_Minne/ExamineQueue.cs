using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public class ExamineQueue
    {
        #region ExamineQueue

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        public void RunExamineQueue()
        {
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
                    {// Användaren vill lägga till en person i kö

                        Console.WriteLine(System.Environment.NewLine);

                        // Hämta inmatningen från tecken 1
                        strInput = strInput.Substring(1);
                        strInput = strInput?.Trim();
                        if (strInput?.Length > 0)
                        {// Lägg till namnet på personen till kö
                            queue.Enqueue(strInput);
                        }

                        PrintQueueToConsole(queue);

                        Console.WriteLine("Enter för att gå vidare");
                        Console.ReadLine();
                    }
                    else if (strInput.StartsWith('0'))
                    {// Användaren vill avsluta och återgå till huvudmenyn

                        //Console.ReadLine();
                        bRun = false;
                    }
                    else if (strInput.StartsWith('1'))
                    {// Användaren vill att innehållet i kö visas

                        PrintQueueToConsole(queue);

                        Console.WriteLine("Enter för att gå vidare");
                        Console.ReadLine();
                    }
                    else if (strInput.StartsWith('2'))
                    {// Användaren vill att en person lämnar kö

                        queue.Dequeue();
                        PrintQueueToConsole(queue);

                        Console.WriteLine("Enter för att gå vidare");
                        Console.ReadLine();
                    }
                    else if (strInput.StartsWith('3'))
                    {// Simulera en kö

                        SimuleraEnKo();
                    }
                    else
                    {
                        Console.WriteLine("Använd + för att lägga till person, 0 för att återgå till huvudmenyn, 1 för att visa kö, 2 för att en person skall lämna kö och 3 för att simulera en kö");
                        Console.ReadLine();
                    }
                }

            } while (bRun);
        }


        /// <summary>
        /// Metoden simulerar att folk ställer sig i en kö och lämnar kö
        /// </summary>
        private void SimuleraEnKo()
        {
            int iRandomValue = 0;
            string strName = String.Empty;
            string strRemovedName = String.Empty;
            Random random = new Random();
            Queue<string> queue = new Queue<string>();

            Console.WriteLine("Nu simuleras en kö. Vänta tills det är klart");
            Console.WriteLine("ICA öppnar och kö till kassan är tom");

            for (int i = 0; i < 25; i++)
            {
                iRandomValue = random.Next(0, 3);

                switch (iRandomValue)
                {
                    case 0: // Inget händer med kö
                        break;
                    case 1: // En person ställer sig i kö
                        strName = Helper.GetRandomName();
                        Console.WriteLine($"{strName} ställer sig i kö");
                        queue.Enqueue(strName);
                        PrintQueueToConsole(queue);
                        Console.WriteLine(System.Environment.NewLine);
                        break;
                    case 2: // En person lämnar kö
                        try
                        {
                            strRemovedName = queue.Dequeue();
                            Console.WriteLine($"{strRemovedName} lämnar kö");
                            PrintQueueToConsole(queue);
                            Console.WriteLine(System.Environment.NewLine);
                        }
                        catch (Exception)
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
        /// Metoden skriver ut information om kö till console
        /// </summary>
        /// <param name="queeue">Kö med personer som vi skall skriva ut information om</param>
        private void PrintQueueToConsole(Queue<string> queeue)
        {
            StringBuilder strBuilder = new StringBuilder($"Följande personer står i kö ({queeue.Count}). ");

            int iCount = 0;
            foreach (string str in queeue)
            {
                if (iCount > 0)
                    strBuilder.Append(", ");

                strBuilder.Append(str);
                iCount++;
            }

            Console.WriteLine(strBuilder.ToString());
        }

        #endregion  // End of region ExamineQueue
    }
}

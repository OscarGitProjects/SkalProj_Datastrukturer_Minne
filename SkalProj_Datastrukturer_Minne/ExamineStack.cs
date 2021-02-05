using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public class ExamineStack
    {

        #region ExamineStack

        /// <summary>
        /// Examines the datastructure Stack
        /// 
        /// Simulera ännu en gång ICA-kö på papper. Denna gång med en stack . Varför är det inte så smart att använda en stack i det här fallet?
        ///     En stack är en så kallad LIFO samling av data. Det innebär att det som adderades sist är det som hämtas först. 
        ///     Vilket är tvärt imot en kö som är en så kalald FIFO samling av data. Där den som adderades först hämtas först
        ///
        /// </summary>
        public void RunExamineStack()
        {
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
                        foreach (char ch in strInput)
                        {
                            stacken.Push(ch.ToString());
                        }

                        PrintStackToConsole(stacken);

                        Console.WriteLine("Enter för att gå vidare");
                        Console.ReadLine();
                    }
                }

            } while (bRun);
        }


        /// <summary>
        /// Metoden skriver ut information om stacken till consolen
        /// </summary>
        /// <param name="stacken">Stack med information som  skall skrivas ut</param>
        private void PrintStackToConsole(Stack<string> stacken)
        {
            StringBuilder strBuilder = new StringBuilder($"Följande tecken finns i stacken ({stacken.Count}). ");

            int iCount = 0;

            foreach (string str in stacken)
            {
                if (iCount > 0)
                    strBuilder.Append(", ");

                strBuilder.Append(str);
                iCount++;
            }

            Console.WriteLine(strBuilder.ToString());
        }

        #endregion  // End of region ExamineStack
    }
}
